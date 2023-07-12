using System.Xml.Linq;
using TodoApi.Models;

namespace TodoApi.Services
{
    public static class CamisetaService
    {
        static List<Camiseta> Lcamisetas { get; }
        static int nextId = 3;
        static CamisetaService()
        {
            Lcamisetas = new List<Camiseta>
        {
            new Camiseta { Id = 1, Name = "Iron Maiden", Tamaño = "XXL"},
            new Camiseta { Id = 2, Name = "Korn" , Tamaño = "M"}
        };
        }

        public static List<Camiseta> GetAll() => Lcamisetas;

        public static void DeleteAll()
        {
            Lcamisetas.Clear();
        }
        public static Camiseta? Get(int id) => Lcamisetas.FirstOrDefault(p => p.Id == id);

        public static void Add(Camiseta camiseta)
        {
            camiseta.Id = nextId++;
            Lcamisetas.Add(camiseta);
        }

        public static void Delete(int id)
        {
            var camiseta = Get(id);
            if (camiseta is null)
                return;

            Lcamisetas.Remove(camiseta);
        }

        public static void Update(Camiseta camiseta)
        {
            var index = Lcamisetas.FindIndex(p => p.Id == camiseta.Id);
            if (index == -1)
                return;

            Lcamisetas[index] = camiseta;
        }


    }
}
