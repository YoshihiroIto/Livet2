﻿using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("Livet2")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Masanori Onoue")]
[assembly: AssemblyProduct("Livet2")]
[assembly: AssemblyCopyright("Copyright © 2015 Masanori Onoue All Rights Reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible を false に設定すると、その型はこのアセンブリ内で COM コンポーネントから 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// このプロジェクトが COM に公開される場合、次の GUID が typelib の ID になります
[assembly: Guid("a6fefddc-d4d9-4bb9-adee-8afc6f008e53")]

// アセンブリのバージョン情報は次の 4 つの値で構成されています:
//
//      メジャー バージョン
//      マイナー バージョン
//      ビルド番号
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってビルドおよびリビジョン番号を 
// 既定値にすることができます:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]

[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Commands")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Converters")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Messaging")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Behaviors")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Messaging.IO")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Messaging.Windows")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Behaviors.Messaging")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Behaviors.Messaging.IO")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Behaviors.Messaging.Windows")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Behaviors.ControlBinding")]
[assembly: XmlnsDefinition("http://schemas.livet-mvvm.net/2011/wpf", "Livet.Behaviors.ControlBinding.OneWay")]
