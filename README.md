# 📦 SmartInventory - PT. Global Logistik
> **Proyek Lomba Kompetensi Siswa (LKS) - IT Solution for Business** > **Wilayah: Jakarta Timur | [cite_start]Tahun: 2026** [cite: 2, 3, 5]

SmartInventory adalah aplikasi manajemen inventaris berbasis desktop yang dirancang khusus untuk **PT. Global Logistik**. [cite_start]Aplikasi ini mendigitalisasi proses pencatatan suku cadang kendaraan yang sebelumnya berbasis kertas untuk meningkatkan akurasi data stok secara *real-time*[cite: 8, 10, 11].

---

## 🚀 Fitur Utama

### 1. 🔐 Akses Sistem (Identity Management)
[cite_start]Halaman login sebagai gerbang utama untuk memverifikasi identitas pengguna sebelum mengakses fitur logistik[cite: 30, 31].
* **Username & Password:** Autentikasi resmi yang didaftarkan oleh administrator[cite: 33].
* [cite_start]**Password Visibility:** Ikon mata untuk melihat karakter kata sandi guna menghindari kesalahan input[cite: 34].
* [cite_start]**Session Trust:** Opsi untuk tetap masuk (logged in) selama 30 hari pada perangkat pribadi[cite: 37, 38].

### 2. 📋 Master Barang (Inventory Management)
[cite_start]Pusat pengelolaan aset dan kontrol stok barang secara efisien[cite: 120, 121].
* [cite_start]**Search & Filter:** Mencari barang berdasarkan SKU/Nama dan memfilter berdasarkan kategori (Electronics, Packaging, dll)[cite: 123, 124].
* **Status Indikator:** Indikator visual kondisi stok:
  * [cite_start]🟣 **In Stock:** Stok mencukupi[cite: 137].
  * [cite_start]🔴 **Low Stock:** Stok menipis (angka stok berwarna merah)[cite: 134, 138].
  * ⚪ **Out of Stock:** Stok kosong[cite: 138].
* [cite_start]**Export Data:** Mengunduh daftar inventaris ke format Excel/CSV untuk laporan luar jaringan[cite: 126].

### 3. ➕ Modul Stock In (Penambahan)
[cite_start]Mencatat penambahan fisik barang yang masuk ke gudang untuk menjaga riwayat mutasi tetap akurat[cite: 207, 208].
* **Reasoning:** Setiap penambahan harus disertai alasan (misal: PO Supplier, Retur, atau Stock Opname)[cite: 215, 217, 218, 219].

### 4. ➖ Modul Stock Out (Pengurangan)
Mencatat pengurangan barang secara resmi karena penjualan atau alasan teknis lainnya[cite: 236, 237].
* [cite_start]**Audit Trail:** Setiap pengurangan dicatat atas nama profil Administrator untuk mencegah manipulasi data[cite: 247].
* [cite_start]**Adjustment Category:** Pilihan alasan pengeluaran seperti *Sold*, *Damaged*, atau *Expired*[cite: 245, 246].

---

## 🛠️ Persyaratan Teknis (Requirements)

Sesuai instruksi kompetisi, aplikasi ini harus memenuhi standar berikut:
1. [cite_start]**Database:** Import file SQL yang telah disediakan dan pastikan konfigurasi relasi tabel tepat[cite: 14, 15].
2. [cite_start]**Layouting:** Implementasi antarmuka yang presisi (*pixel-perfect*) dan responsif sesuai prototype Figma[cite: 17, 18].
3. [cite_start]**Logic:** Penanganan validasi formulir dan integrasi data database yang akurat sesuai *business requirements*[cite: 20, 21].

---

## 💻 Cara Instalasi

1. **Persiapan Database:**
   * [cite_start]Import file `database.sql` ke database engine lokal Anda[cite: 14].
2. **Konfigurasi Aplikasi:**
   * Sesuaikan koneksi database pada file konfigurasi kode program.
3. **Menjalankan Aplikasi:**
   * Buka project melalui IDE pilihan Anda dan lakukan *Build/Run*.

---

## 📐 Skema Data Inventaris

| Atribut | Fungsi |
| :--- | :--- |
| **SKU (ID)** | [cite_start]Kode unik otomatis yang dihasilkan oleh sistem (Read-only)[cite: 179, 180]. |
| **Harga (IDR)** | [cite_start]Nilai nominal harga satuan untuk valuasi total aset[cite: 184, 185]. |
| **Initial Stock** | [cite_start]Jumlah fisik barang saat pertama kali didaftarkan[cite: 186]. |

---

**Dibuat oleh:** [Nama Anda]  
[cite_start]**Tanggal:** 21 April 2026 [cite: 6]  
[cite_start]*Project ini dikembangkan untuk mematuhi standar IT Solution for Business pada LKS 2026.* [cite: 1, 5]
