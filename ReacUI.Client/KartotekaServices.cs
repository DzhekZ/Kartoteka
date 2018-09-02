using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kartoteka.Model;

namespace ReacUI.Client
{
    public interface IChitateliKartotekiService
    {
        Task<IEnumerable<Chitateli>> Get();
    }

    public class ChitateliKartotekiService : IChitateliKartotekiService
    {
        public async Task<IEnumerable<Chitateli>> Get()
        {
            await Task.Delay(1);
            KartotekaManage kartotekaManage = new KartotekaManage();
            return new List<Chitateli>(kartotekaManage.ChitateliKartoteki.Select(x => x));
        }
    }

    public interface IChitateliKartotekiLightService
    {
        Task<IEnumerable<User>> Get();
    }

    public class ChitateliKartotekiLightService : IChitateliKartotekiLightService
    {
        public async Task<IEnumerable<User>> Get()
        {
            await Task.Delay(1);
            KartotekaManage kartotekaManage = new KartotekaManage();
            return new List<User>(kartotekaManage.ChitateliKartotekiLight.Select(x => x));
        }
    }

    public interface IBooksCatalogService
    {
        Task<IEnumerable<BookCatalog>> Get();
    }

    public class BooksCatalogService : IBooksCatalogService
    {
        public async Task<IEnumerable<BookCatalog>> Get()
        {
            await Task.Delay(1);
            KartotekaManage kartotekaManage = new KartotekaManage();
            return new List<BookCatalog>(kartotekaManage.BooksCatalog.Select(x => x));
        }
    }

    public interface IBooksCatalogLightService
    {
        Task<IEnumerable<Book>> Get();
    }

    public class BooksCatalogLightService : IBooksCatalogLightService
    {
        public async Task<IEnumerable<Book>> Get()
        {
            await Task.Delay(1);
            KartotekaManage kartotekaManage = new KartotekaManage();
            return new List<Book>(kartotekaManage.BooksCatalogLight.Select(x => x));
        }
    }
}
