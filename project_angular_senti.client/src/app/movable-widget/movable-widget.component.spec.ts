import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovableWidgetComponent } from './movable-widget.component';

describe('MovableWidgetComponent', () => {
  let component: MovableWidgetComponent;
  let fixture: ComponentFixture<MovableWidgetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MovableWidgetComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(MovableWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
