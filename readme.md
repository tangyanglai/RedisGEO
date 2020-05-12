# RedisGEO

## 简介

基于Redis Geo的封装库，提供Abp模块的封装。



## Nuget

| 名称              | 说明              | Nuget                                                        |
| ----------------- | ----------------- | ------------------------------------------------------------ |
| RedisGEO.Core     | 核心库        | [![Nuget](https://buildstats.info/nuget/RedisGEO.Core)](https://www.nuget.org/packages/RedisGEO.Core/) |
| RedisGEO.Core.Abp | Abp模块 | [![Nuget](https://buildstats.info/nuget/RedisGEO.Core.Abp)](https://www.nuget.org/packages/RedisGEO.Core.Abp/) |



## 开始使用

### ABP方式

以下是使用Abp相关模块，使用起来比较简单：

1. 引用对应的Nuget包
   如：

   nuget:Install-Package RedisGEO.Core
   
   nuget:Install-Package RedisGEO.Core.Abp

2. 添加模块依赖
   在对应工程的Abp的模块（AbpModule）中，添加对“RedisGEOModule”的依赖，如：

````C#
[DependsOn(typeof(RedisGEOModule))]


public override void PreInitialize()
{
   ...........
        
   Configuration.UseGeoRedis(options =>
   {
       options.ConnectionString = appConfiguration["GeoRedis:ConnectionString"];
   });
}
````

3. 配置

appsettings.json下面添加配置文件，格式为：

````json
{
  "GeoRedis": {
    "ConnectionString": "localhost:6379,password=,connectTimeout=,connectRetry=,defaultDatabase="
  }
}
````

4. 使用GeoAPI

通过容器获得IGeoServer，然后调用发送方法即可。

````C#
        private readonly IGeoServer _igeoServer;
        private const string GeoKey = "Place";

        public GeoHelper(IGeoServer igeoServer)
        {
             _igeoServer = igeoServer;
        }
        
        /// <summary>
        /// 插入或修改Geo坐标队列数据
        /// </summary> 
        public async Task<bool> AddOrUpdateAsync(string Name, decimal Latitude, decimal Longitude)
        { 
                return await _igeoServer.GeoAddAsync(new AddInput() { Key = GeoKey, Name = Name, Latitude = Latitude, Longitude = Longitude }); 
        }
````

### 非ABP方式

直接实例化GeoServer使用。