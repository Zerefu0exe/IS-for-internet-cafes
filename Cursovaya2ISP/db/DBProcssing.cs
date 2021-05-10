using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Cursovaya2ISP.db
{
    class DBProcssing
    {
        private static readonly string rootfile = $"Data Source=../../db/database.db";

        public Dictionary<int, string> GetDictUser
        {
            get
            {
                var result = new Dictionary<int, string>();

                using (var connection = new SqliteConnection(rootfile))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        select
                            user.Клиент_id,
                            user.Имя,
                            user.Фамилия
                        from Клиенты as user
                        ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0) ,$"{reader.GetString(1)} {reader.GetString(2)}");
                        }
                    }
                }
                return result;
            }
        }
        public IEnumerable<DataUser> GetDataUser(int id)
        {
            var result = new List<DataUser>();

            using (var connection = new SqliteConnection(rootfile))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                        select 
	                        visitor.Начало_сеанса, 
	                        visitor.Конец_сеанса, 
	                        visitor.Дата, 
	                        pc.Имя, 
	                        staff.Имя, 
	                        staff.Фамилия,
	                        staff.Должность
                        from
	                        Клиенты as user,
	                        Посетительи as visitor,
	                        Компьюторы as pc,
	                        Персонал as staff
                        where
	                        visitor.Клиент_id = user.Клиент_id
	                        and visitor.Компьютор_id = pc.Компьютор_id
	                        and visitor.Персонал_id = staff.Персонал_id
	                        and user.Клиент_id = $id";
                command.Parameters.AddWithValue("$id", id);
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DataUser(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                    }
                }
            }
            return result;
        }
        public void AddDataUser(string name, string surname)
        {
            using (var connection = new SqliteConnection(rootfile))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = 
                    @"
                        insert into Клиенты
                            (Имя, Фамилия)
                        values
                            ($name, $surname)
                    ";

                command.Parameters.AddWithValue("$name", name);
                command.Parameters.AddWithValue("$surname", surname);
                command.ExecuteNonQuery();
            }
        }

        public Dictionary<int, string> GetDictPC
        {
            get
            {
                var result = new Dictionary<int, string>();

                using (var connection = new SqliteConnection(rootfile))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = 
                        @"
                            select
                                pc.Компьютор_id,
                                pc.Имя
                            from Компьюторы as pc
                        ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
                return result;
            }
        }
        public void AddDataPC(string name)
        {
            using (var connection = new SqliteConnection(rootfile))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        insert into Компьюторы
                            (Имя)
                        values
                            ($name)
                    ";

                command.Parameters.AddWithValue("$name", name);
                command.ExecuteNonQuery();
            }
        }

        public Dictionary<int, string> GetDictStaff
        {
            get
            {
                var result = new Dictionary<int, string>();

                using (var connection = new SqliteConnection(rootfile))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = 
                        @"
                            select 
                                staff.Персонал_id,
                                staff.Имя, 
                                staff.Фамилия 
                            from Персонал as staff
                        ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0), $"{reader.GetString(1)} {reader.GetString(2)}");
                        }
                    }
                }
                return result;
            }
        }
        public void AddDataStaff(string name, string surname, string posion)
        {
            using (var connection = new SqliteConnection(rootfile))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        insert into Персонал
                            (Имя, Фамилия, Должность)
                        values
                            ($name, $surname, $posion)
                    ";

                command.Parameters.AddWithValue("$name", name);
                command.Parameters.AddWithValue("$surname", surname);
                command.Parameters.AddWithValue("$posion", posion);
                command.ExecuteNonQuery();
            }
        }
    }
}
