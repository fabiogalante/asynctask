using System.Threading.Tasks;
using LocaWeb.ListagemTweets.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocaWeb.ListagemTweets.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {

        private readonly ITweets _tweets;

        public TwitterController(ITweets tweets)
        {
            _tweets = tweets;
        }

        [HttpGet]
        [Route("most_relevants")]
        public async Task<IActionResult> ObterMaisRelevantes()
        {
            var tweets = await _tweets.ObterMaisRelevantes();
            return new OkObjectResult(tweets);
            

        }

        [HttpGet]
        [Route("most_mentions")]
        public async Task<IActionResult> ObterMaisMencionados()
        {
            var tweets = await _tweets.ObterMaisMencionados();
            return new OkObjectResult(tweets);


        }
    }
}