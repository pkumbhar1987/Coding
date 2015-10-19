using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace RedisDemo
{
    public static class RedisCache
    {
        public static void SaveSession(Guid sessionId, Guid accountId, DateTime expiryTimestamp, bool isValid, bool isSingleUse,
                                int sessionLifeTime, bool isSlidingWindow, Guid applcationId, int validationCount,
                                int presentValidation)
        {
            var session = new SaveSessionEntities()
                {
                    SessionId = sessionId,
                    AccountId = accountId,
                    ExpiryTimestamp = expiryTimestamp,
                    IsValid = isValid,
                    IsSingleUse = isSingleUse,
                    SessionLifeTime=sessionLifeTime,
                    IsSlidingWindow = isSlidingWindow,
                    ApplcationId = applcationId,
                    ValidationCount = validationCount,
                    PresentValidation = presentValidation,
                    CreationTimestamp = DateTime.Now,
                    LastAccessedTimestamp = DateTime.Now
                };

            using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            {
                redisClient.Set<SaveSessionEntities>(Constants.Session + sessionId.ToString(), session, expiryTimestamp);                            
            }           
        }

        public static void SaveTokens(Guid sessionId, NameValueCollection tokens)
        {
            if (tokens == null || tokens.Count == 0) return;

            var oTokens = tokens.AllKeys.Select(name => new SaveToken()
            {
                TokenId = Guid.NewGuid(),
                SessionId = sessionId,
                Name = name,
                Value = tokens[name]
            }).ToList();

            using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            {
                redisClient.Set<List<SaveToken>>(Constants.Token + sessionId.ToString(), oTokens, DateTime.Now.AddMinutes(10));

                var setvalue= redisClient.Get<List<SaveToken>>(Constants.Token + sessionId.ToString());
            }
          
            //foreach (var name in tokens.AllKeys)
            //{
            //    var token = new SaveToken()
            //    {
            //        TokenId = Guid.NewGuid(),
            //        SessionId = sessionId,
            //        Name = name,
            //        Value = tokens[name]
            //    };

            //    using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            //    {
            //        redisClient.Set<SaveToken>(Constants.Token + token.TokenId, token, DateTime.Now.AddDays(5));                    
            //    }
            //}
            //using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            //{
            //    var token = redisClient.GetAll<SaveToken>(new[] {string.Format("{0}{1}", Constants.Token, sessionId)});
            //}
        }

        public static void SaveAdministratorSession(Guid sessionId, string authenticationToken, bool isValid,
                                             DateTime expiryDate)
        {

            var administratorSession = new SaveAdministratorSession()
                {
                    SessionId = sessionId,
                    AuthenticationToken = authenticationToken,
                    IsValid = isValid,
                    ExpiryDate = expiryDate
                };

            using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            {
                redisClient.Set<SaveAdministratorSession>(Constants.AdminToken + sessionId.ToString(), administratorSession, expiryDate);                
            }            
        }

        public static void DeleteTokens(Guid sessionId)
        {
            using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            {
                redisClient.Remove(Constants.Token + sessionId.ToString());                
            }
        }

        public static DataSet GetSession(Guid sessionId)
        {
            SaveSessionEntities session = null;
            SaveToken token = null;
            var ds=new DataSet();
            using (IRedisClient redisClient = PooledRedisClientInstanceManager.GetRedisClient())
            {
                session = redisClient.Get<SaveSessionEntities>(Constants.Session + sessionId.ToString());                               
                                               
                token= redisClient.Get<SaveToken>(Constants.Token + sessionId.ToString());                
            }
            
            DataTable dtSession = GetdtSession(session);
            ds.Tables.Add(dtSession);            

            return new DataSet();
        }

        public static DataTable GetdtSession(SaveSessionEntities session)
        {
            var dt = new DataTable();
            dt.Columns.Add("CreationTimestamp");
            dt.Columns.Add("ExpiryTimestamp");
            dt.Columns.Add("IsValid");
            dt.Columns.Add("LastAccessedTimestamp");
            dt.Columns.Add("Id");
            dt.Columns.Add("AccountId");
            dt.Columns.Add("ApplicationId");
            dt.Columns.Add("IsSingleUse");
            dt.Columns.Add("IsSlidingWindow");
            dt.Columns.Add("SessionLifeTime");
            dt.Columns.Add("ValidationCount");
            dt.Columns.Add("PresentValidations");
            if (session != null)
            {
                var dr = dt.NewRow();
                dr["CreationTimestamp"] = session.CreationTimestamp;
                dr["ExpiryTimestamp"] = session.ExpiryTimestamp;
                dr["IsValid"] = session.IsValid;
                dr["LastAccessedTimestamp"] = session.LastAccessedTimestamp;
                dr["Id"] = session.SessionId;
                dr["AccountId"] = session.AccountId;
                dr["ApplicationId"] = session.ApplcationId;
                dr["IsSingleUse"] = session.IsSingleUse;
                dr["IsSlidingWindow"] = session.IsSlidingWindow;
                dr["SessionLifeTime"] = session.SessionLifeTime;
                dr["ValidationCount"] = session.ValidationCount;
                dr["PresentValidations"] = session.PresentValidation;
                dt.Rows.Add(dr);
            }
            return dt;
        }
                
    }
}
