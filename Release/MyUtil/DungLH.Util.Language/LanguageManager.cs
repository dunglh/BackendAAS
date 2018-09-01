using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DungLH.Util.Language
{
    public enum LanguageEnum
    {
        Vi,
        En
    }
    public class LanguageManager
    {
        private static LanguageEnum languageEnum;
        private static ResourceDictionary viDic = null;
        private static ResourceDictionary enDic = null;

        public static void SetLanguageDictionary(Window window, LanguageEnum target = LanguageEnum.Vi)
        {
            languageEnum = target;
            if (enDic == null)
            {
                enDic = new ResourceDictionary();
                enDic.Source = new Uri("pack://application:,,,/Common.Resource;component/Resource/LangResource.En.xaml", UriKind.Relative);
            }

            if (viDic == null)
            {
                viDic = new ResourceDictionary();
                viDic.Source = new Uri("pack://application:,,,/Common.Resource;component/Resource/LangResource.Vi.xaml", UriKind.Relative);
            }

            switch (languageEnum)
            {
                case LanguageEnum.En:
                    window.Resources.MergedDictionaries.Remove(viDic);
                    window.Resources.MergedDictionaries.Add(enDic);
                    break;
                case LanguageEnum.Vi:
                    window.Resources.MergedDictionaries.Remove(enDic);
                    window.Resources.MergedDictionaries.Add(viDic);
                    break;
                default:
                    window.Resources.MergedDictionaries.Remove(enDic);
                    window.Resources.MergedDictionaries.Add(viDic);
                    break;
            }
        }

        public static void SetLanguageForComponent(UserControl item)
        {
            if (enDic == null)
            {
                enDic = new ResourceDictionary();
                enDic.Source = new Uri("pack://application:,,,/Common.Resource;component/Resource/LangResource.En.xaml", UriKind.Relative);
            }

            if (viDic == null)
            {
                viDic = new ResourceDictionary();
                viDic.Source = new Uri("pack://application:,,,/Common.Resource;component/Resource/LangResource.Vi.xaml", UriKind.Relative);
            }

            switch (languageEnum)
            {
                case LanguageEnum.En:
                    item.Resources.MergedDictionaries.Remove(viDic);
                    item.Resources.MergedDictionaries.Add(enDic);
                    break;
                case LanguageEnum.Vi:
                    item.Resources.MergedDictionaries.Remove(enDic);
                    item.Resources.MergedDictionaries.Add(viDic);
                    break;
                default:
                    break;
            }
        }

        public static LanguageEnum GetLanguage() => languageEnum != null ? languageEnum : LanguageEnum.Vi;
    }
}
