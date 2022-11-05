$(document).ready(function () {

	$(".movie-image").hover(function () {
		$(this).find(".showdetail").show();

	},
		function () {
			$(this).find(".showdetail").hide();
		});


	$(".blink").focus(function () {
		if (this.title == this.value) {
			this.value = '';
		}
	})
		.blur(function () {
			if (this.value == '') {
				this.value = this.title;
			}
		});
});
