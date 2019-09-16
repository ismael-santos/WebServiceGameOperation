using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using GameOperation.Models;
using Dominio;
using Aplicacao.PlayerApp;
using Aplicacao.GameApp;
using GameOperation.GameOperationServiceReference;

namespace GameOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlayerAplicacao _appPlayer;
        private readonly GameAplicacao _appGame;

        public HomeController()
        {
            _appPlayer = PlayerConstrutor.PlayerAplicacao();
            _appGame = GameConstrutor.GameAplicacao();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarPlayer()
        {            
            var player = new Player();
            return View(player);
        }

        [HttpPost]
        public ActionResult CadastrarPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            else
            {
                _appPlayer.Salvar(player);
                return Redirect("/");
            }
        }

        public ActionResult VisualizarTop100()
        {
            try
            {                
                GameOperationServiceClient leader = new GameOperationServiceClient();
                List<Leaderboard> lstLeader = leader.ListarLeaderboard().ToList();

                ViewBag.ListLeaderboard = lstLeader;
                ViewBag.InfoServico = "";

                Response.AddHeader("Refresh", "5");
            }
            catch
            {
                ViewBag.ListLeaderboard = new List<Leaderboard>();
                ViewBag.InfoServico = "* Serviço temporariamento indisponível";
            }

            return View();
        }

        public ActionResult AtualizarPontuacao()
        {
            List<SelectListItem> players = new List<SelectListItem>();

            foreach (var item in _appPlayer.ListarTodos())
            {
                players.Add(new SelectListItem { Text = item.UserName, Value = item.Id.ToString() });
            }

            ViewBag.Players = players;

            List<SelectListItem> games = new List<SelectListItem>();

            foreach (var item in _appGame.ListarTodos())
            {
                games.Add(new SelectListItem { Text = item.GameName, Value = item.Id.ToString() });
            }

            ViewBag.Games = games;

            return View(new GameResultDTO());
        }

        [HttpPost]
        public ActionResult AtualizarPontuacao(GameResultDTO result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            else
            {
                try
                {
                    GameOperationServiceClient service = new GameOperationServiceClient();
                    service.InserirResultado(result.playerId, result.gameId, result.win);
                    ViewBag.InfoServico = "";

                    return Redirect("/");
                }
                catch
                {
                    ViewBag.InfoServico = "* Serviço temporariamento indisponível";
                }

                return AtualizarPontuacao();
            }
        }

    }
}