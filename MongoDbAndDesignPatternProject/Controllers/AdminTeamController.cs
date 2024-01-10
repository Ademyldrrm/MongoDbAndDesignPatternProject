using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;
using MongoDbAndDesignPatternProject.CQRSPattern.Queries;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminTeamController : Controller
    {
        private readonly GetTeamQueryHandler _teamQueryHandler;
        private readonly CreateTeamQueryHandler _createTeamQueryHandler;
        private readonly GetTeamByIdQueryHandler _teamByIdQueryHandler;
        private readonly UpdateTeamCommandHandler _updateTeamCommand;
        private readonly DeleteTeamCommandHandler _deleteTeamCommand;

        public AdminTeamController(GetTeamQueryHandler teamQueryHandler, CreateTeamQueryHandler createTeamQueryHandler, GetTeamByIdQueryHandler teamByIdQueryHandler, UpdateTeamCommandHandler updateTeamCommand, DeleteTeamCommandHandler deleteTeamCommand)
        {
            _teamQueryHandler = teamQueryHandler;
            _createTeamQueryHandler = createTeamQueryHandler;
            _teamByIdQueryHandler = teamByIdQueryHandler;
            _updateTeamCommand = updateTeamCommand;
            _deleteTeamCommand = deleteTeamCommand;
        }

        public IActionResult Index()
        {
            var values = _teamQueryHandler.Handle();
            return View(values);
        }
        [HttpGet] 
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamCommand createTeamCommand)
        {
            _createTeamQueryHandler.Handle(createTeamCommand);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateTeam(string id)
        {
            var values=_teamByIdQueryHandler.Handle(new GetTeamByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateTeam(UpdateTeamCommand command)
        {
            _updateTeamCommand.Handle(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteTeam(string id)
        {
            _deleteTeamCommand.Handle(new DeleteTeamCommand(id));
            return RedirectToAction("Index");
        }
    }
}
