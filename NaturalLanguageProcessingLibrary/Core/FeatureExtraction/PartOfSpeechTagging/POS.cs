using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.FeatureExtraction.PartOfSpeechTagging
{
    public class POS
    {
        public Tag[] GenerateTagArray(string[] words)
        {
            Tag[] tags = new Tag[words.Length];


            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;database=nlm's;userid=root;password=Saniroot");

            int i = 0;
            foreach (string word in words)
            {
                //Console.WriteLine("word-" + word);



                string[] queries = new string[] {

                    String.Format(

                        "SELECT * from nlp_data WHERE word = '{0}' {1} {2};"

                        , word
                        , (i < words.Length - 1 ? "and `next` like '" + words[i + 1] + "~%'" : "")
                        , (i > 0 ? "and `previous` like '" + words[i - 1] + "~%'" : "and `previous` like ''")

                        ),
                    String.Format(

                        "SELECT * from nlp_data WHERE word = '{0}' {1} {2};"

                        , word
                        , (i < words.Length - 1 ? "or `next` like '" + words[i + 1] + "~%'" : "")
                        , (i > 0 ? "and `previous` like '" + words[i - 1] + "~%'" : "and `previous` like ''")

                        ),
                    String.Format(

                        "SELECT * from nlp_data WHERE word = '{0}' {1} {2};"

                        , word
                        , (i < words.Length - 1 ? "and `next` like '" + words[i + 1] + "~%'" : "")
                        , (i > 0 ? "or `previous` like '" + words[i - 1] + "~%'" : "and `previous` like ''")

                        ),
                    String.Format(

                        "SELECT * from nlp_data WHERE word = '{0}' {1} {2};"

                        , word
                        , (i < words.Length - 1 ? "or `next` like '" + words[i + 1] + "~%'" : "")
                        , (i > 0 ? "or `previous` like '" + words[i - 1] + "~%'" : "and `previous` like ''")

                        )

            };


                bool found = false;
                foreach (string query in queries)
                {
                    if (!found)
                    {
                        //Console.WriteLine(query);
                        try
                        {
                            conn.Open();
                        }
                        catch (Exception error)
                        {

                        }

                        MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        Tag tag = Tag.UNKNOWN;
                        //Console.WriteLine(dt.Rows.Count + " results");
                        if (dt.Rows.Count > 0)
                        {
                            found = true;
                            foreach (DataRow row in dt.Rows)
                            {

                                foreach (DataColumn col in dt.Columns)
                                {
                                    try
                                    {
                                    }
                                    catch (Exception e)
                                    {

                                    }
                                    if (col.ColumnName.Equals("type"))
                                    {

                                        tag = new TagInterpreter().match((string)row[col]);
                                    }
                                }
                            }
                        }
                        else
                        
                        tags[i] = tag;
                    }

                }


                i += 1;
            }
            return tags;
        }

    }
}
