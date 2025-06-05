using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //建立连接语句
        //charset=utf8这句要写，不然可能会报错                                 
        string constr = "server=localhost; User Id=root; password=123456; Database=sourse; charset=utf8mb3";

        //建立连接
        MySqlConnection mycon = new MySqlConnection(constr);
        //打开连接
        mycon.Open();
        print("连接成功!");

        //插入数据
        MySqlCommand mycmd = new MySqlCommand("insert into studentscores(id,name,score) values (3,'lisi',100)", mycon);
        if (mycmd.ExecuteNonQuery() > 0)
        {
            print("Insert success!");
        }

        //查询数据
        string selstr = "select * from studentscores";
        MySqlCommand myselect = new MySqlCommand(selstr, mycon);

        DataSet ds = new DataSet();

        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(selstr, mycon);
            da.Fill(ds);
            print("Query success!");
            print(ds.Tables[0].Rows[0][0]);
        }
        catch (Exception e)
        {
            throw new Exception("SQL:" + selstr + "\n" + e.Message.ToString());
        }
        //关闭连接
        mycon.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
