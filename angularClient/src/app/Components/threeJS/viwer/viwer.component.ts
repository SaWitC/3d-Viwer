import { Component,Input, OnInit } from '@angular/core';
import * as THREE from 'three';
import { Color } from 'three';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls'


import { GLTF, GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';

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
  @Input() CameraPositionZ: string;
  @Input() BgColor: string;
  @Input() Turning: boolean = true;



  ngOnInit(): void {

    var parentDomElement = document.getElementById(this.parentElementId)
    if (parentDomElement != null) {

      //console.log(parentDomElement.offsetWidth);
      //console.log(parentDomElement.offsetHeight);


      const renderer = new THREE.WebGLRenderer();
      renderer.setSize(parentDomElement.offsetWidth, parentDomElement.offsetHeight);


      const scene = new THREE.Scene();
      //set bg color
      this.BgColor = "#" + this.BgColor;
      var isCorrectColor = new RegExp("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")

      if (isCorrectColor.test(this.BgColor)) {
        //scene.background = new THREE.Color(this.BgColor)
        renderer.setClearColor(0x000000,0);
      }
      else {
        scene.background = new THREE.Color("#fff")
      }



      ///const camera = new THREE.PerspectiveCamera(75, parentDomElement.offsetWidth / parentDomElement.offsetHeight, 0.1, 1000);
      const camera = new THREE.PerspectiveCamera(75, parentDomElement.offsetWidth / parentDomElement.offsetHeight, 0.1, 1000);

      //Set into dom
        parentDomElement.appendChild(renderer.domElement)
      //else
      //document.body.appendChild(renderer.domElement);///////update not insert in body

      //const controls = new OrbitControls(camera, renderer.domElement)
      // controls.autoRotat=

      const loader = new GLTFLoader();

      var model;

      loader.load(this.ModelUrl, function (gltf) {


        //loader.load('https://downloader.disk.yandex.ru/disk/639b3303702523350d9293e5a5448cd8db979cdb0a90c7f7e460efc7dfba7b5e/630b46c5/ZN2nqGcHJidTFqbu4GvgPAQyWOO1JEG8iItmwr-IKjhV4PhisHQrHzq_yUHbrg6nOCFCQ1kvI7Ev8PfXc1ZZQQ%3D%3D?uid=1616600905&filename=Mushroom%20House.glb&disposition=attachment&hash=&limit=0&content_type=application%2Foctet-stream&owner_uid=1616600905&fsize=2263656&hid=22fd76ce75ad5bde8bf4bdebc637c5da&media_type=data&tknv=v2&etag=c3cb53d22db56d8403ddb32d35e2e639', function (gltf: GLTF) {
        model = gltf.scene;
        let box3 = new THREE.Box3().setFromObject(model);
        let center = new THREE.Vector3();
        box3.getCenter(center);
        console.log(center);
        model.position.sub(center);

        console.log(model.position);
        scene.add(model);
        console.log(model)

      }, undefined, function (error) {
        console.log(error);
      });

      const color = "#444";//light
      const intensity = 10;
      const light = new THREE.AmbientLight(color, intensity);
      scene.add(light);


      //camer setting

      var cameraPositionZ = Number.parseInt(this.CameraPositionZ);
      if (cameraPositionZ > 0 && cameraPositionZ < 1000) {
        camera.position.z = cameraPositionZ;
      }
      else {
        camera.position.z = 100;
      }
      //render
      renderer.render(scene, camera);
      //animation
      if (this.Turning) {
        function animate() {
          //camera =  THREE.PerspectiveCamera(75, parentDomElement.offsetWidth / parentDomElement.offsetHeight, 0.1, 1000);
          if (parentDomElement != null)
            renderer.setSize(parentDomElement.offsetWidth, parentDomElement.offsetHeight);

          requestAnimationFrame(animate);
          model.rotateY(0.002);
          renderer.render(scene, camera);
        };

        animate()
      }


      ////////
      //window.addEventListener('resize', onWindowResize, false)
      //function onWindowResize() {
      //  camera.aspect = parentDomElement.offsetWidth / parentDomElement.offsetHeight
      //  camera.updateProjectionMatrix()
      //  renderer.setSize(parentDomElement.offsetWidth, parentDomElement.offsetHeight)
      //  render()
      //}

      //function render() {
      //  renderer.render(scene, camera)
      //}
    }
  }

  constructor() {
   
  }
   
}
