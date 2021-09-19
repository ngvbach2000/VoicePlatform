import 'package:flutter/foundation.dart';

class VoiceActor {
  final String id;
  final String imageUrl;
  final String name;
  final String bio;
  final String gender;
  final String voiceType;
  final int pricePerOneWord;
  final double rating;

  VoiceActor({
    required this.id,
    required this.imageUrl,
    required this.name,
    required this.bio,
    required this.gender,
    required this.voiceType,
    required this.pricePerOneWord,
    required this.rating,
  });
}
