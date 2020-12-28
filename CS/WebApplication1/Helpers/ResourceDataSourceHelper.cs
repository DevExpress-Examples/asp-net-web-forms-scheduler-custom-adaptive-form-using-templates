using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers {
    public class ResourceDataSourceHelper {
        public ResourceDataSourceHelper() { }

        public static List<CustomResource> GetCustomResources() {
            List<CustomResource> list = new List<CustomResource>();
            for(int i = 1; i <= 3; i++) {
                list.Add(new CustomResource() { Caption = "Resource " + i.ToString(), Color = Color.LightCoral, ResourceId = i });    
            }
            return list;
        }
    }

    public class CustomResource {
        public CustomResource() { }

        public string Caption { get; set; }
        public Color Color { get; set; }
        public int ResourceId { get; set; }
    }
}