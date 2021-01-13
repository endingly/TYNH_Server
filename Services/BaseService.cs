using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TYNH_server.Models;
using System.Collections.Generic;

namespace TYNH_server.Services
{
    public class BaseService<T> where T : BaseModel
    {
        private readonly IMongoCollection<T> _collection;   //数据表操作对象

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">数据库连接</param>
        /// <param name="tableName">表名</param>
        public BaseService(IConfiguration config, string tableName)
        {
            var client = new MongoClient(config.GetConnectionString("TYNH"));    //获取链接字符串

            var database = client.GetDatabase(config.GetSection("DataBaseSetting:DataBaseName").Value);   //数据库名 （不存在自动创建）

            //获取对特定数据表集合中的数据的访问
            _collection = database.GetCollection<T>(tableName);     // （不存在自动创建）
        }

        //Find<T> – 返回集合中与提供的搜索条件匹配的所有文档。
        //InsertOne – 插入提供的对象作为集合中的新文档。
        //ReplaceOne – 将与提供的搜索条件匹配的单个文档替换为提供的对象。
        //DeleteOne – 删除与提供的搜索条件匹配的单个文档。

        /// <summary>
        /// 获取集合内的所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> Get()
        {
            return _collection.Find(T => true).ToList();
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(string id)
        {
            return _collection.Find<T>(T => T.id == id).FirstOrDefault();
        }

        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public T Create(T u)
        {
            _collection.InsertOne(u);
            return u;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="id">指定需要替换数据的id</param>
        /// <param name="TIn">指定数据源</param>
        public void Update(string id, T TIn)
        {
            _collection.ReplaceOne(T => T.id == id, TIn);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="TIn"></param>
        public void Remove(T TIn)
        {
            _collection.DeleteOne(T => T.id == TIn.id);
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id">指定id</param>
        public void Remove(string id)
        {
            _collection.DeleteOne(T => T.id == id);
        }
    }
}