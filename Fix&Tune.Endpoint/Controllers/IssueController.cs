using AutoMapper;
using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fix_Tune.Endpoint.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin, Mechanic")]
    [Route("[controller]")]
    public class IssueController:ControllerBase
    {
        UserManager<User> _userManager;
        IIssueLogic issueLogic;
        IMapper _mapper;

        public IssueController(UserManager<User> userManager, IIssueLogic issueLogic, IMapper mapper)
        {
            _userManager = userManager;
            this.issueLogic = issueLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Issue> GetIssues()
        {
            return issueLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Issue GetIssue(int id)
        {
            return issueLogic.Read(id);
        }

        [HttpPut]
        public IActionResult UpdateIssue(Issue issue) { 
        
            issueLogic.Update(issue);
            return Ok(issue);
        }

        [HttpDelete]
        public IActionResult DeleteIssue(int id)
        {
            issueLogic.Delete(id);
            return Ok("Deleted: " + id);
        }

    }
}
