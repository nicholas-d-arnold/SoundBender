﻿// navigator.mediaDevices.getUserMedia -> to get audio stream from microphone
// MediaRecorder (constructor) -> create MediaRecorder instance for a stream
// MediaRecorder.ondataavailable -> event to listen to when the recording is ready
// MediaRecorder.start -> start recording
// MediaRecorder.stop -> stop recording (this will generate a blob of data)
// URL.createObjectURL -> to create a URL from a blob, which we can use as audio src

var recordButton, stopButton, recorder, audio;

window.onload = function () {
    recordButton = document.getElementById('record');
    stopButton = document.getElementById('stop');
    choosedeviceBtn = document.getElementById('deviceBtn');
    audio = document.getElementById('audio');
    // get audio stream from user's mic

    navigator.mediaDevices.getUserMedia({
        audio: true
    })

        .then(function (stream) {
            recordButton.disabled = false;
            recordButton.addEventListener('click', startRecording);
            stopButton.addEventListener('click', stopRecording);
            recorder = new MediaRecorder(stream);

            // listen to dataavailable, which gets triggered whenever we have
            // an audio blob available
            recorder.addEventListener('dataavailable', onRecordingReady);
        });
};

function startRecording() {
    recordButton.disabled = true;
    stopButton.disabled = false;

    recorder.start();
}

function stopRecording() {
    recordButton.disabled = false;
    stopButton.disabled = true;

    // Stopping the recorder will eventually trigger the `dataavailable` event and we can complete the recording process
    recorder.stop();
}

function onRecordingReady(e) {

    // e.data contains a blob representing the recording
    var audioFile = URL.createObjectURL(e.data);
    audio.src = URL.createObjectURL(e.data);
    audio.play();

    saveit();
}

function saveit() {

    var fileData = new FormData();
    // fetch can make a request to the server and uses promises
    fetch(audio.src).then(response => response.blob())
        .then(blob => {
            fileData.append("file", blob, "file.ogg");
            fileData.append('name', "test");
            fileData.append("description", "something here");
            return fetch("/Home/RecordFile", { method: "POST", body: fileData })
        })



            
}