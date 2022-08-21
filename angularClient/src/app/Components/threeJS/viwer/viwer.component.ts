import { Component,Input, OnInit } from '@angular/core';
import * as THREE from 'three';

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


  ngOnInit(): void {


    var scene = new THREE.Scene();
    var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

    var renderer = new THREE.WebGLRenderer({ alpha: true, antialias: true });///////
    renderer.setClearColor("#fff",0)
    renderer.setSize(window.innerWidth, window.innerHeight);

    var elem = document.getElementById(this.parentElementId);
    console.log(this.parentElementId)
    if (elem != null) {
      console.log("not null")
      elem.appendChild(renderer.domElement)
    }

    //document.body.appendChild(renderer.domElement);

    var geometry = new THREE.BoxGeometry(1, 1, 1);
    var material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
    //var cube = new THREE.Mesh(geometry, material);
    //scene.add(cube);

    var loader = new GLTFLoader()//////
    //loader.load(this.ModelUrl, function (gltf) {
    //  var obj = gltf;
    //  obj.scene.scale.set(1.3, 1.3, 1.3)
    //  scene.add(obj.scene);
    //});

    loader.load("C:\Users\USER\Pictures\blender\art1.gltf", function (gltf) {
      var obj = gltf;
      obj.scene.scale.set(1.3, 1.3, 1.3)
      scene.add(obj.scene);
    });

    camera.position.z = 5;

    //var animate = function () {
    //  requestAnimationFrame(animate);

    //  cube.rotation.x += 0.01;
    //  cube.rotation.y += 0.01;

    //  renderer.render(scene, camera);
    //};

    //animate();
  }
  path: string;

  constructor() {
   
  }
   
}
