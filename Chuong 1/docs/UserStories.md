# CÂU LẠC BỘ HIẾN MÁU

## Câu 1. User Stories

### US-01 · Sinh viên: đăng ký lịch hiến máu

- Có đợt hiến máu còn chỗ → sinh viên đăng ký → hệ thống tạo thông tin đăng ký và lưu trạng thái đăng ký.
- Đợt hiến máu đã đủ số lượng → sinh viên đăng ký → hệ thống thông báo đã đủ số lượng.

### US-02 · Ban CLB: kiểm tra trạng thái thành viên

- Thành viên có thông tin hợp lệ → kiểm tra trạng thái → hệ thống xác định trạng thái thành viên.
- Thành viên cần cập nhật thông tin → cập nhật thông tin → hệ thống lưu thông tin mới.

### US-03 · Ban CLB: xác nhận đăng ký hiến máu

- Sinh viên đã đăng ký → xác nhận đăng ký → hệ thống chuyển trạng thái đăng ký sang đã xác nhận.
- Sinh viên không tiếp tục tham gia → hủy đăng ký → hệ thống chuyển trạng thái đăng ký sang đã hủy.

### US-04 · Ban CLB: ghi nhận điểm danh

- Sinh viên đã đăng ký và đến tham gia → ghi nhận điểm danh → hệ thống lưu thời gian đến.
- Sinh viên chưa có đăng ký → ghi nhận điểm danh → hệ thống không ghi nhận điểm danh.

### US-05 · Ban CLB: ghi nhận kết quả hiến máu

- Sinh viên đủ điều kiện → ghi nhận kết quả → hệ thống lưu nhóm máu, trạng thái đủ điều kiện và kết quả hiến máu.
- Sinh viên không đủ điều kiện → ghi nhận kết quả → hệ thống lưu trạng thái không đủ điều kiện và kết quả tương ứng.

### US-06 · Ban CLB: quản lý đợt hiến máu

- Thông tin đợt hiến máu hợp lệ → tạo đợt hiến máu → hệ thống lưu thông tin đợt hiến máu.
- Đợt hiến máu đạt giới hạn số lượng → kiểm tra số lượng → hệ thống thông báo đã đủ số lượng đăng ký.

### US-07 · Ban CLB: thống kê đăng ký

- Có dữ liệu đăng ký → đếm số đăng ký → hệ thống hiển thị tổng số lượt đăng ký của đợt hiến máu.
- Chưa có đăng ký → đếm số đăng ký → hệ thống hiển thị số lượt đăng ký bằng 0.

