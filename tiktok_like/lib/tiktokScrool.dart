import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';

class TikTokScroll extends StatefulWidget {
  const TikTokScroll({super.key});

  @override
  State<TikTokScroll> createState() => _TikTokScrollState();
}

class _TikTokScrollState extends State<TikTokScroll> {
  final PageController _pageController = PageController(
    initialPage: 0,
  );
  final List<String> _imageUrls = [
    'https://upload.wikimedia.org/wikipedia/en/thumb/b/b2/Ori_and_the_Blind_Forest_Logo.jpg/220px-Ori_and_the_Blind_Forest_Logo.jpg',
    'https://upload.wikimedia.org/wikipedia/en/thumb/9/96/Lost_in_Random_cover_art.jpg/220px-Lost_in_Random_cover_art.jpg',
    'https://upload.wikimedia.org/wikipedia/en/thumb/0/04/Hollow_Knight_first_cover_art.webp/220px-Hollow_Knight_first_cover_art.webp.png',
    'https://upload.wikimedia.org/wikipedia/en/thumb/5/53/Hollow_Knight_Silksong_cover_art.jpg/220px-Hollow_Knight_Silksong_cover_art.jpg'
  ];

  @override
  void dispose() {
    _pageController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return PageView.builder(
      scrollDirection: Axis.vertical,
      controller: _pageController,
      itemCount: _imageUrls.length,
      itemBuilder: (context, index) {
        return ImageWidget(
          imageUrl: _imageUrls[index],
        );
      },
    );
  }
}

class ImageWidget extends StatelessWidget {
  final String imageUrl;
  const ImageWidget({super.key, required this.imageUrl});

  @override
  Widget build(BuildContext context) {
    return Center(
      child: CachedNetworkImage(
        imageUrl: imageUrl,
        fit: BoxFit.cover,
        height: double.infinity,
        width: double.infinity,
        placeholder: (context, url) =>
            const Center(child: CircularProgressIndicator()),
        errorWidget: (context, url, error) =>
            const Center(child: Icon(Icons.error)),
      ),
    );
  }
}
