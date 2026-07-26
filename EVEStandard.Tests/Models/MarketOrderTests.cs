using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using EVEStandard.Models;
using Xunit;

namespace EVEStandard.Tests.Models;

/// <summary>
/// Deserialization test for MarketOrder to verify correctness with the JsonConverter.
/// </summary>
public class MarketOrderTests
{
    [Fact]
    public void BasicSingleMarketOrder()
    {
        var json = """
                   {
                       "duration": 90,
                       "is_buy_order": false,
                       "issued": "2026-04-26T17:35:29Z",
                       "location_id": 60003760,
                       "min_volume": 1,
                       "order_id": 7283408898,
                       "price": 37080000,
                       "range": "region",
                       "system_id": 30000142,
                       "type_id": 45624,
                       "volume_remain": 4,
                       "volume_total": 24
                     }
                   """;
        var order = JsonSerializer.Deserialize<MarketOrder>(json);

        Assert.NotNull(order);
        Assert.Equal(7283408898, order.OrderId);
        Assert.Equal("region", order.Range);
        Assert.Equal(45624, order.TypeId);
    }

    [Fact]
    public void BasicListMarketOrder()
    {
        var json = """
                   [
                   {
                     "duration": 90,
                     "is_buy_order": false,
                     "issued": "2026-04-26T17:35:29Z",
                     "location_id": 60003760,
                     "min_volume": 1,
                     "order_id": 7283408898,
                     "price": 37080000,
                     "range": "region",
                     "system_id": 30000142,
                     "type_id": 45624,
                     "volume_remain": 4,
                     "volume_total": 24
                   },
                   {
                     "duration": 90,
                     "is_buy_order": false,
                     "issued": "2026-07-21T19:01:04Z",
                     "location_id": 60003760,
                     "min_volume": 1,
                     "order_id": 7383023619,
                     "price": 35990000,
                     "range": "40",
                     "system_id": 30000142,
                     "type_id": 17217,
                     "volume_remain": 2,
                     "volume_total": 2
                   }
                   ]
                   """;

        var orders = JsonSerializer.Deserialize<List<MarketOrder>>(json);
        Assert.NotNull(orders);
        Assert.Equal(2, orders.Count);
        Assert.Equal("region", orders[0].Range);
        Assert.Equal("40", orders[1].Range);
    }

    [Fact]
    public void VerifyUnknownRangeStillReads()
    {
        var json = """
                   {
                       "duration": 90,
                       "is_buy_order": false,
                       "issued": "2026-04-26T17:35:29Z",
                       "location_id": 60003760,
                       "min_volume": 1,
                       "order_id": 7283408898,
                       "price": 37080000,
                       "range": "unknown",
                       "system_id": 30000142,
                       "type_id": 45624,
                       "volume_remain": 4,
                       "volume_total": 24
                     }
                   """;
        var order = JsonSerializer.Deserialize<MarketOrder>(json);

        Assert.NotNull(order);
        Assert.Equal(7283408898, order.OrderId);
        Assert.Equal("unknown", order.Range);
        Assert.Equal(45624, order.TypeId);
    }
}
