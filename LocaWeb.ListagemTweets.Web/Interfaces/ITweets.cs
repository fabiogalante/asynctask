using System.Collections.Generic;
using System.Threading.Tasks;
using LocaWeb.ListagemTweets.Domain.Entities;

namespace LocaWeb.ListagemTweets.Web.Interfaces
{
    public interface ITweets
    {

        Task<string> TwittersLocaweb();
        Task<IEnumerable<TweetsMaisRelevantes>> ObterMaisRelevantes();
        Task<IEnumerable<TweetsMaisMencionadosName>> ObterMaisMencionados();
    }
}
