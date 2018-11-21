** README FILE **

You should create Translations folder with resx files in you Portable class library
PCL
 |
 |-Translations
		 |
		 |- language.resx //for default language
		 |- language.en-EN.resx
		...
	
Initialize file location with correct namespace.
	ResourcesFilePath = "{Project Namespace}.{Translation folder}.{Translation file name}";
						"EnagoraApp.Translations.Language"

Use translations in XAML

 xmlns:i18n="clr-namespace:Momentuan.Classes"
 xmlns:i18n="clr-namespace:Enagora.Plugins.MultiLanguage.Classes"
 Text="{i18n:Translate LoadPhotos}