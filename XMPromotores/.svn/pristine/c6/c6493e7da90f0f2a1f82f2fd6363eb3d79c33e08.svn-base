
    var arrRotator = [];

    function RegisterRotator(img, images, keys, velocity, transition, pauseOver, ChangeFunction) {
        var t = new TRotator(img, images, keys, velocity, transition, pauseOver, ChangeFunction);
        arrRotator[arrRotator.length] = t;
        t.start();
    }

    function TRotatorEventArgs(img) {
        var t = getRotator(img.id);
        this.index = t.current;
        this.src = t.images[this.index];
        this.key = t.allkeys[this.index];
    }

    function TRotator(img, images, keys, velocity, transition, pauseOver, ChangeFunction) {
        this.img = document.getElementById(img);
        this.id = this.img.id;
        this.velocity = velocity;
        this.transition = transition;
        this.pauseOver = pauseOver;
        this.current = 0;
        this.auto = false;
        this.images = images.split("|");
        this.timer = null;
        this.start = rotator_start;
        this.stop = rotator_stop;
        this.show = rotator_show;
        this.mouseOver = rotator_mouseover;
        this.mouseOut = rotator_mouseout;
        this.caption = document.getElementById(this.id + '_caption');
        this.caption.innerHTML = (this.current + 1) + '/' + (this.images.length);
        this.btnPlay = document.getElementById(this.id + '_btnplay');
        this.allkeys = keys.split("|");
        this.onChange = ChangeFunction;
    }

    function rotator_mouseover() {
        if (this.pauseOver && this.auto) {
            clearInterval(this.timer);
        }
    }
    
    function rotator_mouseout() {
        if (this.pauseOver && this.auto) {
            this.start();
        }
    }

    function rotator_show(index) {

        if (this.images[index] == '')
            return false;

        if (this.transition) {
            this.img.style.filter = 'blendTrans(duration=1)';
            if (this.img.filters.blendTrans) this.img.filters.blendTrans.Apply();
            this.img.src = this.images[index];
            this.img.filters.blendTrans.Play();
        }
        else {
            this.img.src = this.images[index];
        }
        this.current = index;
        this.caption.innerHTML = (this.current + 1) + '/' + (this.images.length);
        if (this.onChange != undefined) {
            this.onChange(this, new TRotatorEventArgs(this.img));
        }
    }

    function rotator_start() {
        if (this.images.length > 1) {
            this.auto = true;
            this.timer = setInterval('fncChange("' + this.id + '");', this.velocity);
            this.btnPlay.src = '../imagens/player_pause.png';
        }
    }

    function rotator_stop() {
        this.auto = false;
        clearInterval(this.timer);
        this.btnPlay.src = '../imagens/player_play.png';
    }

    function fncPlayPause(name) {
        var t = getRotator(name);
        if (t.auto) {
            t.stop();
        }
        else {
            t.start();
        }
    }

    function fncChange(image) {
        var t = getRotator(image);
        t.current += 1;
        if (t.current >= (t.images.length)) {
            t.current = 0;
        }
        t.show(t.current);
    }

    function getRotator(name){
        for (var i = 0; i < arrRotator.length; i++) {
            if (arrRotator[i].id == name)
                return arrRotator[i];
        }
        return null;
    }

    function fncNavigateImage(image, inc) {
        var t = getRotator(image);
        t.stop();
        t.current += inc;
        if (t.current < 0) t.current = (t.images.length - 1);
        if (t.current > (t.images.length - 1)) t.current = 0;
        t.show(t.current);
    }

    
