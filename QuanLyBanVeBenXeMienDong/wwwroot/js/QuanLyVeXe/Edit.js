$(document).ready(function () {
    $('#chuyenXeDropdown').change(function () {
        var maChuyen = $(this).val();
        if (maChuyen) {
            $.ajax({
                url: '/QuanLyVeXe/GetAvailableSeats',
                type: 'GET',
                data: { maChuyen: maChuyen },
                success: function (data) {
                    console.log('Dữ liệu trả về:', data); // Debug dữ liệu
                    var gheDropdown = $('#gheDropdown');
                    gheDropdown.empty();

                    // Kiểm tra data.seats tồn tại và có độ dài > 0
                    if (data && data.seats && data.seats.length > 0) {
                        $.each(data.seats, function (index, item) {
                            // Dùng viết thường để khớp với JSON
                            gheDropdown.append($('<option></option>').val(item.value).text(item.text));
                        });
                    } else {
                        gheDropdown.append($('<option></option>').text('Không có ghế trống'));
                    }

                    // Cập nhật MaXe
                    if (data.maXe) {
                        $('#maXeInput').val(data.maXe);
                    }
                },
                error: function (xhr, status, error) {
                    console.log('Lỗi AJAX:', error);
                    alert('Lỗi khi tải danh sách ghế.');
                }
            });
        }
    });
});