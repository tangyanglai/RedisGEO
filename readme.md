# RedisGEO

## 简介

```
Redis3.2版本里面新增的一个功能就是对GEO(地理位置)的支持。

Geo命令：
1).geoadd:将给定的空间元素(纬度、经度、名字)添加到指定的键里面。

2).geopos:从键里面返回所有给定位置元素的位置(经度和纬度)。

3).geodist:返回两个给定位置之间的距离。

4).georadius:以给定的经纬度为中心， 返回键包含的位置元素当中， 与中心的距离不超过给定最大距离的所有位置元素。
在给定以下选项时,命令会返回额外的信息：
withdist:在返回位置元素的同时,将位置元素与中心之间的距离也一并返回.距离的单位和用户给定的范围单位保持一致。
withcoord:将位置元素的经度和纬度也一并返回。
withhash:以52位有符号整数的形式,返回位置元素经过原始geohash编码的有序集合分值。这个选项主要用于底层应用或者调试,实际中的作用不大。
命令默认返回未排序的位置元素。通过以下两个参数,用户可以指定被返回位置元素的排序方式：
asc:根据中心的位置,按照从近到远的方式返回位置元素
desc:根据中心的位置,按照从远到近的方式返回位置元素。 

5).georadiusbymember:这个命令和 GEORADIUS 命令一样， 都可以找出位于指定范围内的元素， 但是中心点是由给定的位置元素决定的。

6).geohash:返回一个或多个位置元素的 Geohash 值。
```

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