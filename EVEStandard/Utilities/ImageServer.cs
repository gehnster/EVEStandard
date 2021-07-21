using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Utilities
{
    /*
     * You can use this service to obtain images related to entities in New Eden. At this time, it is possible to get alliance logos, corp logos, 
     *      character portraits, faction logos, ship renders and inventory type icons in various resolutions.
     *  Corporation logos, alliance logos, inventory type icons and ship renders are returned as transparency-enabled 32 bit PNGs. Character portraits are returned as JPEGs.
     *  If a given image is not found in the database, the service responds with a 302 Moved HTTP response and redirects the HTTP client to a generic image. If you request an image in an invalid size, you get a plain 404.
     *  You are welcome to point your clients and applications directly at the image server and use it as a CDN. You do not need to cache the images and serve them yourself.
    */
    public static class ImageServer
    {
        private const string BASE_URL = "https://images.evetech.net";

        public enum AllianceWidth { x32 = 32, x64 = 64, x128 = 128 }
        public enum CorporationWidth { x32 = 32, x64 = 64, x128 = 128, x256 = 256 }
        public enum CharacterWidth { x32 = 32, x64 = 64, x128 = 128, x256 = 256, x512 = 512, x1024 = 1024 }
        public enum FactionWidth { x32 = 32, x64 = 64, x128 = 128 }
        public enum InventoryTypesWidth { x32 = 32, x64 = 64 }
        public enum ShipAndDroneRendersWidth { x32 = 32, x64 = 64, x128 = 128, x256 = 256, x512 = 512 }

        public static string AllianceImageURL(int allianceId, AllianceWidth width)
        {
            return $"{BASE_URL}/alliances/{allianceId}/logo?size={(int)width}";
        }

        public static string CorporationImageURL(int corpId, CorporationWidth width)
        {
            return $"{BASE_URL}/corporations/{corpId}/logo?size={(int)width}";
        }

        public static string CharacterImageURL(int characterId, CharacterWidth width)
        {
            return $"{BASE_URL}/characters/{characterId}/portrait?size={(int)width}";
        }

        public static string FactionImageURL(int factionId, FactionWidth width)
        {
            return $"{BASE_URL}/alliances/{factionId}/logo?size={(int)width}";
        }

        public static string InventoryImageURL(int typeId, InventoryTypesWidth width)
        {
            return $"{BASE_URL}/types/{typeId}/icon?size={(int)width}";
        }

        public static string ShipAndDroneRenderImageURL(int typeId, ShipAndDroneRendersWidth width)
        {
            return $"{BASE_URL}/types/{typeId}/render?size={(int)width}";
        }
    }
}
