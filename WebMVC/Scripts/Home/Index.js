function Slideshow(slides, numOfSlide) {
    this.slides = slides;
    this.numOfSlide = numOfSlide;
    this.slideIndex = 0;

    this.goToNextSlide = function () {
        this.slideIndex = this.slideIndex++ >= this.numOfSlide ? 0 : this.slideIndex++;
    }

    this.showSlideAuto = function () {

    }

    this.goToSlideIndex = function (index) {

    }
}