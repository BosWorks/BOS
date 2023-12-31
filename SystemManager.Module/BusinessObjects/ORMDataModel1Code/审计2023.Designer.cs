﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SystemManager.Module.BusinessObjects.ora55
{

    public partial class 审计2023 : XPObject
    {
        系统 f系统;
        public 系统 系统
        {
            get { return f系统; }
            set { SetPropertyValue<系统>(nameof(系统), ref f系统, value); }
        }
        decimal fA;
        [DevExpress.Xpo.DisplayName(@"2022年运行维护费总投入金额（万元）")]
        public decimal A
        {
            get { return fA; }
            set { SetPropertyValue<decimal>(nameof(A), ref fA, value); }
        }
        string fB;
        [Size(2)]
        [DevExpress.Xpo.DisplayName(@"是否与运维单位专门签订安全保密协议")]
        public string B
        {
            get { return fB; }
            set { SetPropertyValue<string>(nameof(B), ref fB, value); }
        }
        int fC;
        [DevExpress.Xpo.DisplayName(@"运维人员人数")]
        public int C
        {
            get { return fC; }
            set { SetPropertyValue<int>(nameof(C), ref fC, value); }
        }
        int fD;
        [DevExpress.Xpo.DisplayName(@"系统使用频率
（2022年度累计用户访问/登录次数）")]
        public int D
        {
            get { return fD; }
            set { SetPropertyValue<int>(nameof(D), ref fD, value); }
        }
        string fE;
        [Size(200)]
        [DevExpress.Xpo.DisplayName(@"收集和存储数据主要内容（个人信息、商业数据、国家基础数据、其他请列明）")]
        public string E
        {
            get { return fE; }
            set { SetPropertyValue<string>(nameof(E), ref fE, value); }
        }
        double fF;
        [DevExpress.Xpo.DisplayName(@"数据存储量大小（GB）")]
        public double F
        {
            get { return fF; }
            set { SetPropertyValue<double>(nameof(F), ref fF, value); }
        }
        double fG;
        [DevExpress.Xpo.DisplayName(@"包含医患个人信息条数（万条）")]
        public double G
        {
            get { return fG; }
            set { SetPropertyValue<double>(nameof(G), ref fG, value); }
        }
        string fH;
        [Size(20)]
        [DevExpress.Xpo.DisplayName(@"数据库品牌")]
        public string H
        {
            get { return fH; }
            set { SetPropertyValue<string>(nameof(H), ref fH, value); }
        }
        string fI;
        [Size(2)]
        [DevExpress.Xpo.DisplayName(@"是否采购使用云服务")]
        public string I
        {
            get { return fI; }
            set { SetPropertyValue<string>(nameof(I), ref fI, value); }
        }
        string fJ;
        [Size(10)]
        [DevExpress.Xpo.DisplayName(@"是否通过云计算服务安全评估（请填通过、未通过、未参加）")]
        public string J
        {
            get { return fJ; }
            set { SetPropertyValue<string>(nameof(J), ref fJ, value); }
        }
        string fK;
        [Size(80)]
        [DevExpress.Xpo.DisplayName(@"云服务提供商名称（若没有请填写“无”）")]
        public string K
        {
            get { return fK; }
            set { SetPropertyValue<string>(nameof(K), ref fK, value); }
        }
        string fL;
        [Size(80)]
        [DevExpress.Xpo.DisplayName(@"云服务提供商性质
（党政机关、事业单位、国有企业、民营企业、外资企业、其他请列明）")]
        public string L
        {
            get { return fL; }
            set { SetPropertyValue<string>(nameof(L), ref fL, value); }
        }
        string fM;
        [Size(80)]
        [DevExpress.Xpo.DisplayName(@"信息系统等级保护定级情况
（一级、二级、三级、四级、五级、未定级）")]
        public string M
        {
            get { return fM; }
            set { SetPropertyValue<string>(nameof(M), ref fM, value); }
        }
        int fN;
        [DevExpress.Xpo.DisplayName(@"2022年开展等级保护测评的次数")]
        public int N
        {
            get { return fN; }
            set { SetPropertyValue<int>(nameof(N), ref fN, value); }
        }
        string fO;
        [Size(80)]
        [DevExpress.Xpo.DisplayName(@"容灾备份情况（数据灾备、系统灾备、数据灾备+系统灾备、无灾备）")]
        public string O
        {
            get { return fO; }
            set { SetPropertyValue<string>(nameof(O), ref fO, value); }
        }
        string fP;
        [Size(80)]
        [DevExpress.Xpo.DisplayName(@"网络日志留存情况（格式：**个月，若未留存请填写“未留存”）")]
        public string P
        {
            get { return fP; }
            set { SetPropertyValue<string>(nameof(P), ref fP, value); }
        }
    }

}
