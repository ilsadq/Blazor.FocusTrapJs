import {createFocusTrap} from "focus-trap";

window.blazorFocusTrap = {};
window.blazorFocusTrap.focusTraps ??= new WeakMap();

/**
 * Init focus trap and add to global collection
 * @param {string} id
 * @param dotObj
 * @param {FocusTrapSettings} settings
 */
window.blazorFocusTrap.initFocusTrap = (id, dotObj, settings) => {
    const focusTrap = createFocusTrap(`#${id}`, {
        // Settings
        returnFocusOnDeactivate: settings.returnFocusOnDeactivate,
        clickOutsideDeactivates: settings.clickOutsideDeactivates,
        escapeDeactivates: settings.escapeDeactivates,
        allowOutsideClick: settings.allowOutsideClick,
        preventScroll: settings.preventScroll,
        delayInitialFocus: settings.delayInitialFocus,
        setReturnFocus: settings.setReturnFocusId,
        isKeyBackward: settings.isKeyBackward,
        isKeyForward: settings.isKeyForward,
        // Events
        onActivate: () => dotObj.invokeMethodAsync("OnActivate"),
        onDeactivate: () => dotObj.invokeMethodAsync("OnDeactivate"),
        onPause: () => dotObj.invokeMethodAsync("OnPause"),
        onPostActivate: () => dotObj.invokeMethodAsync("OnPostActivate"),
        onUnpause: () => dotObj.invokeMethodAsync("OnUnpause"),
        onPostPause: () => dotObj.invokeMethodAsync("OnPostPause"),
        onPostDeactivate: () => dotObj.invokeMethodAsync("OnPostDeactivate"),
        onPostUnpause: () => dotObj.invokeMethodAsync("OnPostUnpause"),
    });

    const element = document.getElementById(id);
    window.blazorFocusTrap.focusTraps.set(element, focusTrap);

    if (settings.autoActivate) {
        focusTrap.activate();
    }
}

/**
 * Activate focus trap from collection
 * @param {string} id
 */
window.blazorFocusTrap.activateFocusTrap = (id) => {
    const element = document.getElementById(id);
    const focusTrap = window.blazorFocusTrap.focusTraps.get(element);
    focusTrap.activate();
}

/**
 * Remove focusTrap from collection
 * @param {string} id
 */
window.blazorFocusTrap.disposeTrap = (id) => {
    const element = document.getElementById(id);
    window.blazorFocusTrap.focusTraps.delete(element);
}

/**
 * Settings for the FocusTrap behavior, controlling how the trap activates, deactivates, and handles focus management.
 *
 * @typedef {Object} FocusTrapSettings
 * @property {boolean} [autoActivate=false] - If true, the activation process will run immediately after the initialization completes.
 * @property {boolean} [escapeDeactivates=true] - If false or returns false, the Escape key will not trigger deactivation of the focus trap.
 * @property {boolean} [clickOutsideDeactivates=false] - If true or returns true, a click outside the focus trap will immediately deactivate the focus trap.
 * @property {boolean} [allowOutsideClick=true] - If set and is or returns true, a click outside the focus trap will not be prevented.
 * @property {boolean} [returnFocusOnDeactivate=false] - If false, when the trap is deactivated, focus will not return to the element that had focus before activation.
 * @property {string|null} [setReturnFocusId=null] - The element to which focus should be returned after the focus trap is deactivated. It can be a DOM node, a selector string, or a function.
 * @property {boolean} [preventScroll=true] - If true, no scroll will happen when focus is set.
 * @property {boolean} [delayInitialFocus=true] - Delays the autofocus to the next execution frame when the focus trap is activated.
 * @property {boolean} [isKeyBackward=false] - Determines if the given keyboard event is a "tab backward" event that will move the focus to the previous trapped element in tab order.
 * @property {boolean} [isKeyForward=false] - Determines if the given keyboard event is a "tab forward" event that will move the focus to the next trapped element in tab order.
 */
