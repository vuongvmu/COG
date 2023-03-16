using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class
{
    public enum eLightMaker
    {
        None,
        LVS,
        DaRea
    }

    public enum eImageExtension
    {
        Jpg,
        Bmp,
        Png
    }

    

    public enum eStageNo
    {
        //[Description("tlqkf")]
        Stage1,
    }

    public enum eCameraNo
    {
        PreAlign,
        Inspection1,
        Inspection2,

        //Inspection1 = 0,
        //Inspection2 = 0,
        //PreAlign = 0,
    }

    static class EnumDescription
    {
        public static string GetDescription(this Enum e)
        {
            Type enumType = e.GetType();
            string enumName = Enum.GetName(enumType, e);

            if (enumName != null)
            {
                FieldInfo fieldInfo = enumType.GetField(enumName);

                if (fieldInfo != null)
                {
                    DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    if (descriptionAttribute != null)
                        return descriptionAttribute.Description;
                }
            }

            return string.Empty;
        }
    }
}
