namespace webCucbanquyen.Areas.Quantri.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Tracuuniengiam : DbContext
    {
        public Tracuuniengiam()
            : base("name=Tracuuniengiam")
        {
        }

        public virtual DbSet<ALLCODE> ALLCODEs { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblChiNhanhChuSoHuu> tblChiNhanhChuSoHuus { get; set; }
        public virtual DbSet<tblChiNhanhLog> tblChiNhanhLogs { get; set; }
        public virtual DbSet<tblChiNhanhTacGia> tblChiNhanhTacGias { get; set; }
        public virtual DbSet<tblChiNhanhTacPham> tblChiNhanhTacPhams { get; set; }
        public virtual DbSet<tblChiNhanhThongTinKhac> tblChiNhanhThongTinKhacs { get; set; }
        public virtual DbSet<tblChusohuu> tblChusohuus { get; set; }
        public virtual DbSet<tbldanhsachden> tbldanhsachdens { get; set; }
        public virtual DbSet<tblDmbaocao> tblDmbaocaos { get; set; }
        public virtual DbSet<tblDmQuoctich> tblDmQuoctiches { get; set; }
        public virtual DbSet<tblDmTacpham> tblDmTacphams { get; set; }
        public virtual DbSet<tblLog> tblLogs { get; set; }
        public virtual DbSet<tblNguoiCapCN> tblNguoiCapCNs { get; set; }
        public virtual DbSet<tblTacgia> tblTacgias { get; set; }
        public virtual DbSet<tblTacpham> tblTacphams { get; set; }
        public virtual DbSet<tblTacphamBaocao> tblTacphamBaocaos { get; set; }
        public virtual DbSet<tblThongtinkhac> tblThongtinkhacs { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblDanhsachdenCSH> tblDanhsachdenCSHes { get; set; }
        public virtual DbSet<tblReport> tblReports { get; set; }
        public virtual DbSet<VIEW_ALLCODE> VIEW_ALLCODE { get; set; }
        public virtual DbSet<VIEW_CHINHANH_TBLTACPHAM> VIEW_CHINHANH_TBLTACPHAM { get; set; }
        public virtual DbSet<VIEW_CONGBAO> VIEW_CONGBAO { get; set; }
        public virtual DbSet<View_DMchusohuu> View_DMchusohuu { get; set; }
        public virtual DbSet<View_DMTacgia> View_DMTacgia { get; set; }
        public virtual DbSet<view_Log> view_Log { get; set; }
        public virtual DbSet<VIEW_TACPHAM> VIEW_TACPHAM { get; set; }
        public virtual DbSet<VIEW_TBLCHUSOHUU_CHINHANH> VIEW_TBLCHUSOHUU_CHINHANH { get; set; }
        public virtual DbSet<VIEW_TBLDMQUOCTICH> VIEW_TBLDMQUOCTICH { get; set; }
        public virtual DbSet<VIEW_TBLDMQUOCTICH_CHUSOHUU> VIEW_TBLDMQUOCTICH_CHUSOHUU { get; set; }
        public virtual DbSet<VIEW_TBLDMQUOCTICH_TACGIA> VIEW_TBLDMQUOCTICH_TACGIA { get; set; }
        public virtual DbSet<VIEW_TBLDMTACPHAM> VIEW_TBLDMTACPHAM { get; set; }
        public virtual DbSet<VIEW_TBLNGUOICAPCN> VIEW_TBLNGUOICAPCN { get; set; }
        public virtual DbSet<VIEW_TBLTACGIA_CHINHANH> VIEW_TBLTACGIA_CHINHANH { get; set; }
        public virtual DbSet<VIEW_TBLTACPHAM_CHINHANH> VIEW_TBLTACPHAM_CHINHANH { get; set; }
        public virtual DbSet<VIEW_TBLTACPHAM_TBLDMTACPHAM> VIEW_TBLTACPHAM_TBLDMTACPHAM { get; set; }
        public virtual DbSet<VIEW_TBLTHONGTINKHAC_CHINHANH> VIEW_TBLTHONGTINKHAC_CHINHANH { get; set; }
        public virtual DbSet<VIEW_TBLUSER> VIEW_TBLUSER { get; set; }
        public virtual DbSet<VIEW_TPQUYETDINHTHUHOI> VIEW_TPQUYETDINHTHUHOI { get; set; }
        public virtual DbSet<View_TTniengiam> View_TTniengiam { get; set; }
        public virtual DbSet<VIEW1> VIEW1 { get; set; }
        public virtual DbSet<VIEW2> VIEW2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dtproperty>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<tblChiNhanhThongTinKhac>()
                .Property(e => e.ThuHoiGiayCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblChiNhanhThongTinKhac>()
                .Property(e => e.ThayDoiCSH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_CHINHANH_TBLTACPHAM>()
                .Property(e => e.trangthaiduyet)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_CHINHANH_TBLTACPHAM>()
                .Property(e => e.tenloaidk)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_CHINHANH_TBLTACPHAM>()
                .Property(e => e.nguoidaidien)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_TBLTACPHAM_CHINHANH>()
                .Property(e => e.tenloaidk)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_TBLTACPHAM_CHINHANH>()
                .Property(e => e.trangthaiduyet)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_TBLTACPHAM_CHINHANH>()
                .Property(e => e.nguoidaidien)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_TBLTACPHAM_TBLDMTACPHAM>()
                .Property(e => e.tenloaidk)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_TBLTACPHAM_TBLDMTACPHAM>()
                .Property(e => e.trangthaiduyet)
                .IsUnicode(false);

            modelBuilder.Entity<VIEW_TBLTACPHAM_TBLDMTACPHAM>()
                .Property(e => e.nguoidaidien)
                .IsUnicode(false);
        }
    }
}
