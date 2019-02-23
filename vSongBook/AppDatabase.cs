using System;
using System.Data;
using Finisar.SQLite;

namespace vSongBook
{
   
    public class AppDatabase
    {
        SQLiteConnection sConn;
        SQLiteCommand sCmd;
        SQLiteDataAdapter sAdapter = null;
        DataSet dS = null;
        DataTable dT = new DataTable();
        SQLiteDataReader reader;
        DataRowCollection dRowCol;

        public AppDatabase()
        {
            sConn = new SQLiteConnection("Data Source=db\\vSongBook.db;New=False;Version=3");
            sConn.Open();
        }

        public DataRowCollection getList(string CommandText)
        {
            dS = new DataSet();
            sAdapter = new SQLiteDataAdapter(CommandText, sConn);
            sAdapter.Fill(dS);
            dRowCol = dS.Tables[0].Rows;
            sqlClose();
            return dRowCol;
        }
        public SQLiteDataReader getSingle(string CommandText)
        {
            sCmd = new SQLiteCommand(CommandText, sConn);
            reader = sCmd.ExecuteReader();
            return reader;
        }
        public string textRendertoDB(string songStr)
        {
            songStr = songStr.Replace("'", "^");
            songStr = songStr.Replace('"', '+');
            return songStr;
        }

        public string songRendertoDB(string songStr)
        {
            songStr = songStr.Replace("\r\n\r\n", "|");
            songStr = songStr.Replace("\r\n", "$");
            songStr = songStr.Replace("  ", " ");
            songStr = songStr.Replace("'", "^");
            songStr = songStr.Replace("`", "^");
            songStr = songStr.Replace('"', '+');
            return songStr;
        }

        public string quickUpdate(string table, string column, string value, string columnid, string columnvl)
        {
            string result = "";
            try
            {
                sCmd = new SQLiteCommand("UPDATE " + table + " SET " + column + "=" + value + ", updated='" + todate() +
                    "' WHERE " + columnid + "= " + columnvl, sConn);
                sCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
        public string newSong(string book, string number, string title, string content, string key, string notes, string author)
        {
            string result = "";
            try
            {
                sCmd = new SQLiteCommand("INSERT INTO songs " + "(book, number, title, content, key, notes, author, created) VALUES('" +
                book + "', '" + number + "', '" + textRendertoDB(title) + "', '" + songRendertoDB(content) + "', '" + key + "', '" + 
                    notes + "', '" + author + "', '" + todate() + "')", sConn);
                sCmd.ExecuteNonQuery();
                string songs = columnCount("songs", "book", book);
                quickUpdate("books", "songs", songs, "code", book);
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
         
        public string editSong(int songid, string book, string number, string title, string content, string key, string notes, string author)
        {
            string result = "";
            try
            {
                sCmd = new SQLiteCommand("UPDATE songs SET book='" + book + "', number='" +
                    number + "', title='" + title + "', content='" + content + "', key='" + key + 
                    "', notes='" + notes + "', author='" + author + "', updated='" + todate() + 
                    "' WHERE songid=" + songid, sConn);
                sCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }

        public string columnCount(string table, string column, string value)
        {
            string result = "";
            try
            {
                sCmd = new SQLiteCommand("SELECT COUNT(*) FROM " + table + " WHERE " + column + "= '" + value + "';", sConn);
                sCmd.CommandType = CommandType.Text;
                result = (sCmd.ExecuteScalar()).ToString();
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }

        public string addNewBook(string title, string code, string content)
        {
            string result = "";
            try
            {
                int songs = Convert.ToInt32(columnCount("songs", "book", code));
                sCmd = new SQLiteCommand("INSERT INTO books (title, code, content, songs, created) VALUES('" + title + "', '" + code + "', '" + 
                    content + "', '" + songs + "', '" + todate() + "')", sConn);
                sCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
       
        public string editBook(string bookid, string title, string code, string content)
        {
            string result = "";
            try
            {
                int songs = Convert.ToInt32(columnCount("songs", "book", code));
                sCmd = new SQLiteCommand("UPDATE books SET title='" + title + "', code='" + code + "', content='" + content + 
                    "', songs=" + songs + ", updated='" + todate() + "' WHERE bookid=" + bookid, sConn);
                sCmd.ExecuteNonQuery();
                result = "success";
            }
            catch (Exception sqlex)
            {
                result = sqlex.ToString();
            }
            return result;
        }
        
        public void songsUpdate(string code, int songs)
        {
            try
            {
                sCmd = new SQLiteCommand("UPDATE books SET songs='" + songs.ToString() + "', updated='" +
                    todate() + "' WHERE code=" + code, sConn);
                sCmd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }
        public string todate()
        {
            return DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }

        public void sqlClose()
        {
            sConn.Close();
        }

    }
}
