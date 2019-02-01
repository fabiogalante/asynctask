using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocaWeb.ListagemTweets.Domain.Entities;

namespace LocaWeb.ListagemTweets.Domain.Interfaces
{
    public interface ITweets
    {

        Task<string> TwittersLocaweb();
        Task<IEnumerable<TweetsMaisRelevantes>> ObterMaisRelevantes();
        Task<IEnumerable<TweetsMaisMencionadosName>> ObterMaisMencionados();
    }
}
