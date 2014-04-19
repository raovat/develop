<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="Admin.UC.LeftMenu" %>
<ul class="nav" id="side-menu">
    <%--<li class="sidebar-search">
        <div class="input-group custom-search-form">
            <input type="text" class="form-control" placeholder="Search...">
            <span class="input-group-btn">
                <button class="btn btn-default" type="button">
                    <i class="fa fa-search"></i>
                </button>
            </span>
        </div>
        <!-- /input-group -->
    </li>--%>
    <li>
        <a href="#"><i class="fa fa-dashboard fa-fw"></i> Dashboard</a>
    </li>
    <li>
        <a href="/Pages/Category.aspx"><i class="fa fa-th-list fa-fw"></i> Danh mục</a>
    </li>
    <li>
        <a href="#"><i class="fa fa-bar-chart-o fa-fw"></i> Tin tour<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level">
            <li>
                <a href="flot.html">Flot Charts</a>
            </li>
            <li>
                <a href="morris.html">Morris.js Charts</a>
            </li>
        </ul>
        <!-- /.nav-second-level -->
    </li>
    <li>
        <a href="#"><i class="fa fa-list-alt fa-fw"></i> Tin rao vặt<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level">
            <li>
                <a href="flot.html">Flot Charts</a>
            </li>
            <li>
                <a href="morris.html">Morris.js Charts</a>
            </li>
        </ul>
        <!-- /.nav-second-level -->
    </li>
    <li>
        <a href="#"><i class="fa fa-film fa-fw"></i> Quảng Cáo</a>
    </li>
    <li>
        <a href="#"><i class="fa fa-th-large fa-fw"></i> Banner</a>
    </li>
    <li>
        <a href="#"><i class="fa fa-list-alt fa-fw"></i> Hợp đồng</a>
    </li>
    <li>
        <a href="#"><i class="fa fa-flag fa-fw"></i> Tỉnh/Thành phố<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level">
            <li>
                <a href="#">Quản lý Vùng miền</a>
            </li>
            <li>
                <a href="#">Quốc gia</a>
            </li>
            <li>
                <a href="#">Tỉnh/Thành phố</a>
            </li>
        </ul>
    </li>
    <li>
        <a href="#"><i class="fa fa-user fa-fw"></i> Thành viên</a>
    </li>
    <li>
        <a href="#"><i class="fa fa-cog fa-fw"></i> Người dùng<span class="fa arrow"></span></a>
        <ul class="nav nav-second-level">
            <li>
                <a href="#">Danh sách người dùng</a>
            </li>
            <li>
                <a href="#">Phân quyền</a>
            </li>
        </ul>
        <!-- /.nav-second-level -->
    </li>
    <li>
        <a href="#"><i class="fa fa-envelope fa-fw"></i> Comment</a>
    </li>
</ul>
