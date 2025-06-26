import { Component, input } from "@angular/core";

@Component({
    selector: 'svg[icon]',
    standalone: true,
    imports: [],
    template: '<svg:use [attr.xlink:href]="href"></svg:use>',
    styles: [':host{ width: 30px; height: 30px; }']
})
export class SvgIconComponent{
    icon = input<string>('');

    get href(): string {
        return `/assets/svg/icons.svg#${this.icon()}`;
    }
}