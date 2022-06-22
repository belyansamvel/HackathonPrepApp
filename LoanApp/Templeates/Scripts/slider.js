$(() => {
	let sliderBgs = [
		{
			id: "0",
			backgroundUrl: "https://wallpaperaccess.com/full/320508.jpg"
		},
		{
			id: "1",
			backgroundUrl: "https://cdn.wallpapersafari.com/85/98/gDK8Ic.jpg"
		}
	];

	let slider = $('.ic-slider');
	let imgID = 0;

	changeSliderBg();

	setSliderHeight();
	$(window).resize(e => {
		setSliderHeight();
	});

	let slide = setInterval(() => {
		goNext();
	}, 20000);

	function goNext() {
		changeSliderBg();
	}

	function changeSliderBg() {
		slider.css("background-image", `url('${sliderBgs[imgID].backgroundUrl}')`);
		imgID = imgID < sliderBgs.length - 1 ? imgID + 1 : 0;
	}

	function setSliderHeight() {
		let coefficient = 1080 / 1920 * 0.8;
		let height = Number(slider.css("width").substring(0, slider.css("width").length - 2)) * coefficient;
		//console.log(height);

		slider.css("height", `${height}px`);
	}
})