import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowsernotEnabled3dComponent } from './browsernot-enabled3d.component';

describe('BrowsernotEnabled3dComponent', () => {
  let component: BrowsernotEnabled3dComponent;
  let fixture: ComponentFixture<BrowsernotEnabled3dComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BrowsernotEnabled3dComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BrowsernotEnabled3dComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
