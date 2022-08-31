import { Component, Input, OnInit } from '@angular/core';
import * as THREE from 'three';

@Component({
  selector: 'app-icosaedr',
  templateUrl: './icosaedr.component.html',
  styleUrls: ['./icosaedr.component.css']
})
export class IcosaedrComponent implements OnInit {

  constructor() { }

  @Input() parentElementId: string;

  ngOnInit(): void {

    var parentDomElement = document.getElementById(this.parentElementId)
    if (parentDomElement != null) {
      const scene = new THREE.Scene();
      
      const camera = new THREE.PerspectiveCamera(75, parentDomElement.offsetWidth / parentDomElement.offsetHeight, 0.1, 1000);

      const renderer = new THREE.WebGLRenderer();
      renderer.setSize(parentDomElement.offsetWidth, parentDomElement.offsetHeight);
      renderer.setClearColor(0x000000, 0);

      parentDomElement.appendChild(renderer.domElement)


      var L1 = new THREE.PointLight(0xffffff, 1);
      L1.position.z = 100;
      L1.position.y = 100;
      L1.position.x = 100;
      scene.add(L1);

      var L2 = new THREE.PointLight(0xffffff, 0.8);
      L2.position.z = 200;
      L2.position.y = 50;
      L2.position.x = -100;
      scene.add(L2);

      var pinkMat = new THREE.MeshPhongMaterial({
        color: new THREE.Color("rgb(226,35,213)"),
        emissive: new THREE.Color("rgb(255,128,64)"),
        specular: new THREE.Color("rgb(255,155,255)"),
        shininess: 10,
        //shading: THREE.FlatShading,
        flatShading: true,
        transparent: true,
        opacity: 1
      });

      var Ico = new THREE.Mesh(new THREE.IcosahedronGeometry(1, 2), pinkMat);

      scene.add(Ico);

      
      //.background = new THREE.Color("#440099")
      renderer.render(scene, camera);


      camera.position.z = 2.4;

      function animate() {
        requestAnimationFrame(animate);

        Ico.rotation.x += 0.002;
        Ico.rotation.y += 0.002;

        renderer.render(scene, camera);
      };

      animate();
    }
  }

}
