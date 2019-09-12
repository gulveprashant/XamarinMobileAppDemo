﻿using Safe.BL.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Safe.BL.Managers
{
    public class DatabaseManager
    {
        private string _DatabaseURI;
        private SQLiteAsyncConnection _DbConnection;

        private static DatabaseManager _Instance;

        public static DatabaseManager Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DatabaseManager();
                }
                return _Instance;
            }
        }

        private DatabaseManager()
        {
            String personalFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String databaseFileName = "AppData.db";

            _DatabaseURI = Path.Combine(personalFolderPath, databaseFileName);
        }

        public bool Connect()
        {
            try
            {
                if (_DbConnection == null)
                {
                    _DbConnection = new SQLiteAsyncConnection(_DatabaseURI);
                }
            }
            catch(Exception ex)
            {

            }
            return (_DbConnection != null);
        }

        public bool Disconnect()
        {
            if (_DbConnection != null)
            {
                _DbConnection.CloseAsync();
            }
            return true;
        }

        public async Task<List<Credential>> GetCredentials()
        {
            
            Connect();

            if (_DbConnection != null)
            {
                List<Credential> credentials = new List<Credential>();
                try
                {

                    _DbConnection.CreateTableAsync<Credential>().Wait();
                    credentials = await _DbConnection.Table<Credential>().ToListAsync();

                    Disconnect();
                }
                catch (Exception ex)
                {
                    
                }

                return credentials;
            }

            return null;
        }

        public async Task<List<Note>> GetNotes()
        {

            Connect();

            if (_DbConnection != null)
            {
                List<Note> notes = new List<Note>();
                try
                {

                    _DbConnection.CreateTableAsync<Note>().Wait();
                    notes = await _DbConnection.Table<Note>().ToListAsync();

                    Disconnect();
                }
                catch (Exception ex)
                {

                }

                return notes;
            }

            return null;
        }


        public async Task<bool> AddCredential(Credential credential)
        {
            Connect();
            _DbConnection.CreateTableAsync<Credential>().Wait();
            int recordsAdded = await _DbConnection.InsertAsync(credential);
            Disconnect();
            return recordsAdded != 0;
        }


        public async Task<bool> AddNote(Note note)
        {
            Connect();
            _DbConnection.CreateTableAsync<Note>().Wait();
            int recordsAdded = await _DbConnection.InsertAsync(note);
            Disconnect();
            return recordsAdded != 0;
        }

    }
}
