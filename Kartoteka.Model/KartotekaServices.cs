using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartoteka.Model
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
      return new List<Chitateli>();      
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
      return new List<User>();
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
      return new List<BookCatalog>();
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
      return new List<Book>();
    }
  }
}
