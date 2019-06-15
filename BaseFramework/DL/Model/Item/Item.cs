using System;
using System.Linq;
using Dapper;

// ReSharper disable InconsistentNaming

namespace BaseFramework.DL.Model.Item {
    public class Item : Core.DL.Model.Model {
        public int id;

        public string guid;

        public string title;

        public double price;

        public static Item Find(int id)
            => Connection().Query<Item>(
                "SELECT * FROM items WHERE id = @id LIMIT 1", new {id}
            ).FirstOrDefault();

        public static Item FindByGuid(string guid)
            => Connection().Query<Item>(
                "SELECT * FROM items WHERE guid = @guid LIMIT 1", new {guid}
            ).FirstOrDefault();
        
        public static Item FindByTitle(string title)
            => Connection().Query<Item>(
                "SELECT * FROM items WHERE title = @title LIMIT 1", new {title}
            ).FirstOrDefault();

        public static void Create(string title, double price)
            => ExecuteSql(
                "INSERT INTO public.items(guid, title, price) VALUES (@guid, @title, @price)"
                , new {guid = Guid.NewGuid().ToString(), title, price}
            );
        
        public static int Count() => ExecuteScalarInt("SELECT count(*) FROM items WHERE id = @id LIMIT 1");
    }
}