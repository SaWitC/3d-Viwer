import { Component,Input, OnInit } from '@angular/core';
import * as THREE from 'three';
import { Color } from 'three';

import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';

@Component({
  selector: 'app-viwer',
  templateUrl: './viwer.component.html',
  styleUrls: ['./viwer.component.css']
})
export class ViwerComponent implements OnInit {


  @Input() parentElementId: string;

  @Input() ModelUrl: string

  @Input() Width: number;
  @Input() Height: number;
  @Input() CameraPositionZ: number;
  @Input() BgColor: string;
  @Input() Turning: boolean = false;



  ngOnInit(): void {

    const scene = new THREE.Scene();
    //set bg color
    var isCorrectColor = new RegExp("/^#([0-9a-f]{3}){1,2}$/i")
    if (isCorrectColor.test(this.BgColor)) {
      scene.background = new THREE.Color(this.BgColor)
    }
    else {
      scene.background = new THREE.Color("#fff")
    }

    const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

    const renderer = new THREE.WebGLRenderer();
    renderer.setSize(window.innerWidth, window.innerHeight);
    //Set into dom

    var parentDomElement = document.getElementById(this.parentElementId)
    console.log("2111    "+parentDomElement)
    if (parentDomElement != null)
      parentDomElement.appendChild(renderer.domElement)
    //else
      //document.body.appendChild(renderer.domElement);///////update not insert in body

    const loader = new GLTFLoader();

    var model;

    loader.load(this.ModelUrl, function (gltf) {

    //loader.load('https://downloader.disk.yandex.ru/disk/cfd1ec6493aa85843eaa9a8f70d2cd5f7db09feb4cd6a4f38e8e35f2beb74958/6303e79a/ZN2nqGcHJidTFqbu4GvgPFFqhH-HAP32C4Gm67Ky1D6Hfl-zYa6J1rX2DGSpxtt0Nte7I12nOAs_4HlNH51Jpw%3D%3D?uid=1616600905&filename=art1.gltf&disposition=attachment&hash=&limit=0&content_type=text%2Fplain&owner_uid=1616600905&fsize=2450491&hid=c1240050fda6f8ae659fd69aa8add648&media_type=text&tknv=v2&etag=67faa85a4f486f3e9202af5366f99af0', function (gltf) {
      model = gltf.scene;
      let box3 = new THREE.Box3().setFromObject(model);
      let center = new THREE.Vector3();
      box3.getCenter(center);
      model.position.sub(center);
      scene.add(model);
      console.log(model)

    }, undefined, function (error) {
      console.log(error);
    });

    const color = "#fff";//light
    const intensity = 10;
    const light = new THREE.AmbientLight(color, intensity);
    scene.add(light);


    //camer setting
    if (this.CameraPositionZ > 0 && this.CameraPositionZ < 1000) {
      camera.position.z = this.CameraPositionZ;
    }
    else {
      camera.position.z = 100;
    }
    //render
    renderer.render(scene, camera);
    //animation
    if (this.Turning) {
      function animate() {
        requestAnimationFrame(animate);
        model.rotateY(0.002);
        renderer.render(scene, camera);
      };

      animate()
    }
  }

  constructor() {
   
  }
   
}
