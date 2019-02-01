using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LocaWeb.ListagemTweets.Domain.Entities;
using LocaWeb.ListagemTweets.Web.Interfaces;
using Moq;
using Xunit;

namespace LocaWeb.ListagemTweets.Test
{
    public class LocaWebTwitterUnitTest
    {
        [Fact]
        public async Task Deve_Retornar_Objeto_Mencionados_name()
        {
            var twMoq = new Mock<ITweets>();
            ITweets tweets = twMoq.Object;

            var test = await tweets.ObterMaisMencionados();
            
            test.Should().BeOfType<TweetsMaisMencionadosName[]>();
        }


        [Fact]
        public async Task Deve_Retornar_Objeto_Mencionados()
        {
            
            Mock<ITweets> twMoq = new Mock<ITweets>();

            var objectsList = new List<TweetsMaisMencionadosName>()
            {
                new TweetsMaisMencionadosName()
            };

            twMoq.Setup(
                rep => rep.ObterMaisMencionados()
            ).Returns(Task.FromResult<IEnumerable<TweetsMaisMencionadosName>>(objectsList));

        }
    }
}
