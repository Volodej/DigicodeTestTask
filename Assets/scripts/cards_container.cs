using UnityEngine;

public class cards_container : MonoBehaviour {
    public UIWrapContent wrap_container;
    public UIPanel scroll_view_panel;
    public UIWidget parent_container;

    public card card_prefab;
    public int cards_to_instantiate = 52;

    private int _parent_width;
    private int _parent_heigth;

	void Start () {
        wrap_container.onInitializeItem = on_initialize_item;
	    instantiate_cards(cards_to_instantiate);
        resize_container();
        wrap_container.SortBasedOnScrollMovement();
        wrap_container.WrapContent();
	}

    void Update () {
	    if(_parent_width != parent_container.width || _parent_heigth!=parent_container.height)
            resize_container();
	}

    private void on_initialize_item(GameObject go, int wrapIndex, int realIndex) {
        go.GetComponent<card>().card_depth = realIndex;
    }

    private void instantiate_cards(int cards_number) {
        var wrap_transform = wrap_container.transform;
        for (int i = 0; i < cards_number; i++) {
            var card = Instantiate(card_prefab);
            card.setup_card();

            var card_transform = card.transform;
            card_transform.parent = wrap_transform;
            card_transform.localScale = Vector3.one;
        }
    }

    private void resize_container() {
        _parent_width = parent_container.width;
        _parent_heigth = parent_container.height;
        scroll_view_panel.baseClipRegion = new Vector4(0, 0, _parent_width / 2, scroll_view_panel.height);
    }
}
