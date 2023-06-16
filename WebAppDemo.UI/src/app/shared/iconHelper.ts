import { MatIconRegistry } from "@angular/material/icon";
import { DomSanitizer } from "@angular/platform-browser";
import { IconType } from "./iconType.enum";

export abstract class IconHelper {
    public static getSvgPath(iconType: IconType) {
        return `assets/svg/${iconType}.svg`
    }

    public static registerIcons(iconTypes: IconType[], matIconRegistry :MatIconRegistry, domSanitizer: DomSanitizer ): void {
        iconTypes.forEach(iconType => {
            matIconRegistry.addSvgIcon(iconType, domSanitizer.bypassSecurityTrustResourceUrl(IconHelper.getSvgPath(iconType)));
        });
      }
}