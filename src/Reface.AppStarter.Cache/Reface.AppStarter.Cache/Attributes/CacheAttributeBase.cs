﻿//using System;

//namespace Reface.AppStarter.Attributes
//{
//    public abstract class CacheAttributeBase : Attribute
//    {
//        public CacheAttributeBase() : this("")
//        {

//        }

//        public CacheAttributeBase(string cacheKeyFormatter)
//        {
//            this.CacheKeyFormatter = cacheKeyFormatter;
//        }

//        /// <summary>
//        /// 注入属性，不需要从外部赋值
//        /// </summary>
//        //public ICachePoolAccessor CachePoolAccessor { get; set; }

//        /// <summary>
//        /// 注入属性，不需要从外部赋值
//        /// </summary>
//        //public ICacheKeyGenerator CacheKeyGenerator { get; set; }

//        public string CacheKeyFormatter { get; private set; }

//        //protected string GetKeyWithArguments(MethodInfo methodInfo, object[] arguments)
//        //{
//        //    if (string.IsNullOrEmpty(this.CacheKeyFormatter))
//        //        this.CacheKeyFormatter = this.CacheKeyGenerator.Generate(methodInfo);
//        //    return string.Format(this.CacheKeyFormatter, arguments);
//        //}
//    }
//}
