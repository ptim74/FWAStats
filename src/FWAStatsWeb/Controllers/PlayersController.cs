﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FWAStatsWeb.Models.PlayerViewModels;
using FWAStatsWeb.Data;
using FWAStatsWeb.Models;
using FWAStatsWeb.Logic;
using Microsoft.Extensions.Logging;

namespace FWAStatsWeb.Controllers
{
    [ResponseCache(Duration = Constants.CACHE_NORMAL)]
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IClashApi api;
        private readonly IMemberUpdater memberUpdater;
        private readonly ILogger<PlayersController> logger;

        public PlayersController(
            ApplicationDbContext db,
            IClashApi api,
            IMemberUpdater memberUpdater,
            ILogger<PlayersController> logger)
        {
            this.db = db;
            this.api = api;
            this.memberUpdater = memberUpdater;
            this.logger = logger;
        }

        public IActionResult Index(string q)
        {
            logger.LogInformation("Index {0}", q);

            var model = new SearchViewModel();

            if(!string.IsNullOrEmpty(q))
            {
                model.Query = q;
                model.Results = new List<SearchResultModel>();

                var playerTag = Utils.LinkIdToTag(q);
                var player1 = db.Players.Select(p => new SearchResultModel {
                    Tag = p.Tag,
                    Name = p.Name,
                    LastSeen = p.LastUpdated
                }).SingleOrDefault(p => p.Tag == playerTag);

                if(player1 != null)
                {
                    var member = db.Members.Where(m => m.Tag == player1.Tag).SingleOrDefault();
                    if(member != null)
                    {
                        player1.ClanTag = member.ClanTag;
                        var clan = db.Clans.Where(c => c.Tag == member.ClanTag).SingleOrDefault();
                        if(clan != null)
                        {
                            player1.ClanName = clan.Name;
                        }
                    }
                    model.Results.Add(player1);
                }
                else
                {
                    var clanNames = db.Clans.ToDictionary(c => c.Tag, c => c.Name);

                    #pragma warning disable IDE0031
                    var players = from p in db.Players
                                  where p.Name.ToUpper().Contains(q.ToUpper())
                                  join im in db.Members on p.Tag equals im.Tag into InnerMembers
                                  from m in InnerMembers.DefaultIfEmpty()
                                  select new SearchResultModel
                                  {
                                      Tag = p.Tag,
                                      Name = p.Name,
                                      LastSeen = p.LastUpdated,
                                      ClanTag = (m != null ? m.ClanTag : null)
                                  };
                    #pragma warning restore IDE0031

                    foreach (var player in players.OrderBy(p => p.Name.ToUpper()).Take(100))
                    {
                        if (!string.IsNullOrEmpty(player.ClanTag) && clanNames.ContainsKey(player.ClanTag))
                            player.ClanName = clanNames[player.ClanTag];
                        model.Results.Add(player);
                    }
                }
            }

            return View(model);
        }

        [Route("Player/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            logger.LogInformation("Details {0}", id);

            var tag = Utils.LinkIdToTag(id);

            var ret = new DetailsViewModel
            {
                Events = new List<PlayerDetailsEvent>(),
                Player = await api.GetPlayer(tag)
            };

            memberUpdater.UpdatePlayer(ret.Player, true);

            var events = from e in db.PlayerEvents
                         join v in db.ClanValidities on e.ClanTag equals v.Tag
                         where e.PlayerTag == tag
                         orderby e.EventDate descending
                         select new { Event = e, v.Name };

            foreach (var clanEvent in events.Take(100))
            {
                var e = new PlayerDetailsEvent { Tag = clanEvent.Event.ClanTag, Name = clanEvent.Name, EventDate = clanEvent.Event.EventDate, EventType = clanEvent.Event.EventType, TimeDesc = clanEvent.Event.TimeDesc() };
                if (e.EventType == PlayerEventType.Promote || e.EventType == PlayerEventType.Demote)
                {
                    e.Value = clanEvent.Event.RoleName;
                }
                else if (e.EventType == PlayerEventType.NameChange)
                {
                    e.Value = clanEvent.Event.StringValue;
                }
                else
                {
                    e.Value = clanEvent.Event.Value.ToString();
                }
                ret.Events.Add(e);
            }

            return View(ret);
        }
    }
}
