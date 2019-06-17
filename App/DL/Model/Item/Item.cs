using System;
using System.Linq;
using Dapper;

// ReSharper disable InconsistentNaming

namespace App.DL.Model.Item {
    public class Item : BaseFramework.DL.Model.Model {
        public int id;

        public string guid;

        public string title;

        public decimal price;

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

        public static int Create(string title, double price)
            => ExecuteScalarInt(
                @"INSERT INTO public.items(guid, title, price) VALUES (@guid, @title, @price); SELECT currval('items_id_seq');"
                , new {guid = Guid.NewGuid().ToString(), title, price}
            );

        public Item Save() {
            ExecuteSql(
                "UPDATE items SET title = @title, price = @price WHERE id = @id", new {title, price, id}
            );
            return this;
        }

        public Item Refresh() => Find(id);
        
        public static int Count() => ExecuteScalarInt("SELECT count(*) FROM items WHERE id = @id");
        
        public void Delete() => ExecuteScalarInt("DELETE FROM items WHERE id = @id", new {id});
    }
}