using gs.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gs.Tools
{
    public class DB
    {
        readonly SQLiteAsyncConnection db;
        public DB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);

            db.CreateTableAsync<Types>().Wait();
            db.CreateTableAsync<Ammo>().Wait(); 
            db.CreateTableAsync<Gun>().Wait();
        }

        public Task<List<Types>> GetTypesAsync()
        {
            return db.Table<Types>().ToListAsync();
        }

        public Task<Types> GetTypeAsync(int id)
        {
            return db.Table<Types>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTypeAsync(Types types)
        { 
            if (types.ID != 0)
            {
                return db.UpdateAsync(types);
            }
            else
            {
                return db.InsertAsync(types);
            }
        }

        public Task<int> DeleteTypeAsync(Types types)
        {
            return db.DeleteAsync(types);
        }
        public Task<List<Ammo>> GetAmmosAsync()
        {
            return db.Table<Ammo>().ToListAsync();
        }

        public Task<Ammo> GetAmmoAsync(int id)
        {
            return db.Table<Ammo>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAmmoAsync(Ammo ammo)
        {
            if (ammo.Id != 0)
            {
                return db.UpdateAsync(ammo);
            }
            else
            {
                return db.InsertAsync(ammo);
            }
        }

        public Task<int> DeleteAmmoAsync(Ammo ammo)
        {
            return db.DeleteAsync(ammo);
        }

        public Task<List<Gun>> GetGunsAsync()
        {
            return db.Table<Gun>().ToListAsync();
        }

        public Task<Gun> GetGunAsync(int id)
        {
            return db.Table<Gun>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveGunAsync(Gun gun)
        {
            if (gun.Id != 0)
            {
                return db.UpdateAsync(gun);
            }
            else
            {
                return db.InsertAsync(gun);
            }
        }

        public Task<int> DeleteGunAsync(Gun gun)
        {
            return db.DeleteAsync(gun);
        }
    }
}
