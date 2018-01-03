using FrpGui.propertyentity;
using IniParser.Model;
using System;
using System.Reflection;

namespace FrpGui.models
{
    public static class EntityObjectConvert
    {

        public static string GetSectionName(this IProepertyEntity obj)
        {
            var name = "";
            var type = obj.GetType();
            var info = type.GetProperty("SectionName");
            if (info != null)
            {
                var value = info.GetValue(obj, null);
                name = value == null ? "" : value.ToString();
            }
            return name.ToLower();
        }
       
        public static IProepertyEntity ToEntity(this SectionData data)
        {
            var name = data.Keys["type"].ToUpperFirst();
            if (!string.IsNullOrEmpty(data.Keys["bind_addr"]))
            {
                name = "ServerCommon";
            }
            if (!string.IsNullOrEmpty(data.Keys["server_addr"]))
            {
                name = "ClientCommon";
            }

            var type = Type.GetType("FrpGui.propertyentity." + name + "Section");
            if (type == null)
                return null;
            IProepertyEntity obj = (IProepertyEntity)Activator.CreateInstance(type);
            obj.SectionName = data.SectionName;
            foreach (var item in type.GetProperties())
            {
                if (!item.CanWrite)
                    continue;

                var key = item.Name.ToLower();
                var attr = (PropertyKeyAttribute)item.GetCustomAttribute(typeof(PropertyKeyAttribute));
                if (attr != null)
                {
                    key = attr.Name;
                }
                var value = data.Keys[key];
                if (string.IsNullOrEmpty(value))
                    continue;

                if (item.PropertyType.IsEnum)
                {

                    var changeValue = Enum.Parse(item.PropertyType, value.ToUpperFirst());
                    item.SetValue(obj, changeValue);
                }
                else
                {
                    var changeValue = Convert.ChangeType(value, item.PropertyType);
                    item.SetValue(obj, changeValue);
                }
               
            }
          
            return obj;
        }


        public static IniData ToIniData(this IProepertyEntity obj)
        {
            var sectionName = obj.GetSectionName();
            if (string.IsNullOrEmpty(sectionName))
            {
                return new IniData();
            }
            var sectionData = new SectionData(sectionName);
            var type = obj.GetType();
            foreach (var item in type.GetProperties())
            {
                if (item.GetCustomAttribute(typeof(ObsoleteAttribute)) != null
                     || item.GetCustomAttribute(typeof(SectionNameAttribute)) != null)
                {
                    continue;
                }

                var key = item.Name.ToLower();
                var attr = (PropertyKeyAttribute)item.GetCustomAttribute(typeof(PropertyKeyAttribute));
                if (attr != null)
                {
                    key = attr.Name;
                }
                var value = item.GetValue(obj, null);

                if (value == null
                   || string.IsNullOrWhiteSpace(value.ToString()))
                    continue;

                if (item.PropertyType.Name == typeof(int).Name && (int)value == 0)
                {
                    continue;
                }
                sectionData.Keys.AddKey(key, value.ToString().ToLower());
            }
            var result = new IniData();
            result.Sections.Add(sectionData);
            return result;
        }
    }
}
