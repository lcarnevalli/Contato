using Xunit;
using Contato.Data;
using Contato.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ContactTests
{
    private DbContextOptions<ContactDBContext> dbContextOptions;

    public ContactTests()
    {
        // Configura o uso de um banco de dados em memória para testes
        dbContextOptions = new DbContextOptionsBuilder<ContactDBContext>()
            .UseInMemoryDatabase(databaseName: "ContatoDbTest")
            .Options;

        using (var context = new ContactDBContext(dbContextOptions))
        {
            if (!context.Contacts.Any())
            {
                context.Contacts.Add(new Contact { Nome = "Leonildo", DDD = "11", Telefone = "981270278", Email = "leo@gmail.com" });
                context.Contacts.Add(new Contact { Nome = "Marileide", DDD = "21", Telefone = "981223344", Email = "maril@gmail.com" });
                context.SaveChanges();
            }
        }
    }

    [Fact]
    public async Task FilterByDDDFindsCorrectContacts()
    {
        using (var context = new ContactDBContext(dbContextOptions))
        {
            // Simulação da funcionalidade de filtro
            var contacts = await context.Contacts.Where(c => c.DDD == "11").ToListAsync();

            // Assertivas para verificar se apenas contatos com o DDD "11" são retornados
            Assert.Single(contacts);
            Assert.All(contacts, c => Assert.Equal("11", c.DDD));
        }
    }
}
